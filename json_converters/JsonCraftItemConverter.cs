using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;
using Tests;


namespace JSONConverters;

public class JsonCraftItemConverter : JsonConverter<ICraftItemComponent>
{
  public override ICraftItemComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    if (!root.TryGetProperty("uniqueName", out JsonElement jsonUniqueName))
    {
      throw new JsonException("Invalid item uniqueName. Item does not have a UniqueName property.");
    }

    string uniqueName = jsonUniqueName.GetString() ?? throw new JsonException("Invalid item uniqueName. Item does not have a UniqueName property.");
    return ItemTests.GetCraftItemByUniqueName(uniqueName);
  }

  public override void Write(Utf8JsonWriter writer, ICraftItemComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();

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
