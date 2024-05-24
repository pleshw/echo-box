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
    var debug = root.ToString();

    // Determine the concrete type from the JSON data
    if (root.TryGetProperty("taskType", out JsonElement typeElement))
    {
      int? type = typeElement.GetInt32();
      string rootText = root.GetRawText();

      return (QuestStepTaskType)type switch
      {
        QuestStepTaskType.COLLECTION => JsonSerializer.Deserialize<QuestStepTaskCollection>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskCollection"),
        QuestStepTaskType.HUNT => JsonSerializer.Deserialize<QuestStepTaskHunt>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskHunt"),
        QuestStepTaskType.FIND => JsonSerializer.Deserialize<QuestStepTaskFind>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskFind"),
        QuestStepTaskType.ESCORT => JsonSerializer.Deserialize<QuestStepTaskEscort>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskEscort"),
        QuestStepTaskType.REACH_POSITION => JsonSerializer.Deserialize<QuestStepTaskReachPosition>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachPosition"),
        QuestStepTaskType.REACH_NPC => JsonSerializer.Deserialize<QuestStepTaskReachNPC>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachNPC"),
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
