using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;
using Game;


namespace JSONConverters;

public class JsonBaseInventoryConverter : JsonConverter<IInventoryComponent>
{
  public override IInventoryComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    UniqueNameComponent uniqueName = root.TryGetProperty("owner", out JsonElement jsonUniqueName)
        ? JsonSerializer.Deserialize<UniqueNameComponent>(jsonUniqueName, options) ?? throw new JsonException("Owner not set for inventory.")
        : throw new JsonException("Owner not set for inventory.");

    // Assuming you need to extract more properties, for example "capacity" and "items"
    int capacity = root.TryGetProperty("capacity", out JsonElement jsonCapacity)
        ? jsonCapacity.GetInt32()
        : throw new JsonException("Invalid inventory capacity. Inventory does not have a Capacity property.");

    JsonElement itemsElement = root.TryGetProperty("items", out JsonElement jsonItems)
        ? jsonItems
        : throw new JsonException("Invalid item items. Item does not have an Items property.");

    List<IItemSlotComponent> itemList = itemsElement.EnumerateArray()
                                                      .Select(item => JsonSerializer.Deserialize<ItemSlotComponent>(item.GetRawText(), options)
                                                           ?? throw new JsonException("Invalid item in items array."))
                                                      .Cast<IItemSlotComponent>()
                                                      .ToList();

    BaseEntity inventoryOwner = EntityTests.GetEntityByUniqueName(uniqueName.UniqueName);

    return new InventoryComponent
    {
      Owner = inventoryOwner,
      Items = itemList,
      MaxStackSize = capacity,
    };
  }

  public override void Write(Utf8JsonWriter writer, IInventoryComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString("type", value.GetType().AssemblyQualifiedName);

    var propertiesNotIgnored = value.GetType()
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(prop => !Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute)));

    foreach (var prop in propertiesNotIgnored)
    {
      string propertyName = prop.Name;

      // Apply naming policy if defined
      if (options.PropertyNamingPolicy != null)
      {
        propertyName = options.PropertyNamingPolicy.ConvertName(propertyName);
      }

      writer.WritePropertyName(propertyName);
      JsonSerializer.Serialize(writer, prop.GetValue(value), prop.PropertyType, options);
    }

    writer.WriteEndObject();
  }
}
