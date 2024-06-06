using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonDisplayImageConverter : JsonConverter<IDisplayImageComponent>
{
  public override IDisplayImageComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    if (!doc.RootElement.TryGetProperty("type", out JsonElement typeElement))
    {
      throw new JsonException("Missing type discriminator");
    }

    string typeName = typeElement.GetString() ?? throw new JsonException($"Unknown type: {typeElement.GetString()}"); ;
    Type type = Type.GetType(typeName) ?? throw new JsonException($"Unknown type: {typeName}");
    return JsonSerializer.Deserialize(doc.RootElement.GetRawText(), type, options) as IDisplayImageComponent ?? throw new JsonException($"Invalid Conversion for: {typeName}"); ;
  }

  public override void Write(Utf8JsonWriter writer, IDisplayImageComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString("type", value.GetType().AssemblyQualifiedName);

    IDisplayImageComponent valueAsBriefing = value;

    var propertiesNotIgnored = typeof(DisplayImageComponent)
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
      JsonSerializer.Serialize(writer, prop.GetValue(valueAsBriefing), prop.PropertyType, options);
    }

    writer.WriteEndObject();
  }
}
