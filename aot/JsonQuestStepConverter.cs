using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Quest;


namespace AOT;

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public class JsonQuestStepTaskConverter : JsonConverter<SerializableQuestStepTask>
{
  public override SerializableQuestStepTask Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    // Read the JSON document
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    // Determine the concrete type from the JSON data
    if (root.TryGetProperty("Type", out JsonElement typeElement))
    {
      string? type = typeElement.GetString();
      string rootText = root.GetRawText();

      return type switch
      {
        nameof(QuestStepTaskCollection) => JsonSerializer.Deserialize<QuestStepTaskCollection>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskCollection"),
        nameof(QuestStepTaskHunt) => JsonSerializer.Deserialize<QuestStepTaskHunt>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskHunt"),
        nameof(QuestStepTaskFind) => JsonSerializer.Deserialize<QuestStepTaskFind>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskFind"),
        nameof(QuestStepTaskEscort) => JsonSerializer.Deserialize<QuestStepTaskEscort>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskEscort"),
        nameof(QuestStepTaskReachPosition) => JsonSerializer.Deserialize<QuestStepTaskReachPosition>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachPosition"),
        nameof(QuestStepTaskReachNPC) => JsonSerializer.Deserialize<QuestStepTaskReachNPC>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachNPC"),
        null => throw new JsonException("Unknown type"),
        _ => throw new JsonException("Unknown type"),
      };
    }

    throw new JsonException("Type property not found");
  }

  public override void Write(Utf8JsonWriter writer, SerializableQuestStepTask value, JsonSerializerOptions options)
  {
    // Determine the concrete type and serialize accordingly
    switch (value)
    {
      case QuestStepTaskCollection a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestStepTaskHunt a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestStepTaskFind a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestStepTaskEscort a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestStepTaskReachPosition a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestStepTaskReachNPC a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
