using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;
using Tests;


namespace JSONConverters;

public class JsonStageConverter : JsonConverter<StageComponent>
{
  public override StageComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    string uniqueName = root.TryGetProperty("uniqueName", out JsonElement jsonUniqueName)
        ? jsonUniqueName.GetString() ?? throw new JsonException("uniqueName not set for inventory.")
        : throw new JsonException("Owner not set for inventory.");

    JsonElement jsonEntityList = root.TryGetProperty("entityList", out JsonElement _jsonEntityList)
        ? _jsonEntityList
        : throw new JsonException("Invalid item items. Item does not have an Items property.");

    List<IUniqueNameComponent> uniqueNameEntityList = jsonEntityList.EnumerateArray()
                                                      .Select(item => JsonSerializer.Deserialize<IUniqueNameComponent>(item.GetRawText(), options)
                                                           ?? throw new JsonException("Invalid item in items array."))
                                                      .Cast<IUniqueNameComponent>()
                                                      .ToList();

    List<IUniqueNameComponent> entityList = EntityTests.GetEntitiesByUniqueName(uniqueNameEntityList).Cast<IUniqueNameComponent>().ToList();

    IGridMapComponent cellList = root.TryGetProperty("gridMap", out JsonElement _jsonGridMap)
            ? JsonSerializer.Deserialize<GridMapComponent>(_jsonGridMap.GetRawText(), options) ?? throw new JsonException("Invalid item in gridMap object.")
            : throw new JsonException("Stage does not have a GridMap property.");

    return new StageComponent
    {
      UniqueName = uniqueName,
      EntityList = entityList,
      GridMap = cellList
    };
  }

  public override void Write(Utf8JsonWriter writer, StageComponent value, JsonSerializerOptions options)
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
