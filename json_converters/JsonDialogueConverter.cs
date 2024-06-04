using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonDialogueConverter : JsonConverter<IDialogueComponent>
{
  public override IDialogueComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    if (!doc.RootElement.TryGetProperty("Type", out JsonElement typeElement))
    {
      throw new JsonException("Missing type discriminator");
    }

    string typeName = typeElement.GetString() ?? throw new JsonException($"Unknown type: {typeElement.GetString()}"); ;
    Type type = Type.GetType(typeName) ?? throw new JsonException($"Unknown type: {typeName}");
    return JsonSerializer.Deserialize(doc.RootElement.GetRawText(), type, options) as IDialogueComponent ?? throw new JsonException($"Invalid Conversion for: {typeName}"); ;
  }

  public override void Write(Utf8JsonWriter writer, IDialogueComponent value, JsonSerializerOptions options)
  {
    switch (value)
    {
      case DialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestDialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
