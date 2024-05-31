using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serializable;


namespace AOT;

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public class JsonQuestTaskConverter : JsonConverter<SerializableQuestTask>
{
  public override SerializableQuestTask Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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

      return (QuestTaskType)type switch
      {
        QuestTaskType.COLLECTION => JsonSerializer.Deserialize<QuestTaskCollection>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskCollection"),
        QuestTaskType.HUNT => JsonSerializer.Deserialize<QuestTaskHunt>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskHunt"),
        QuestTaskType.FIND => JsonSerializer.Deserialize<QuestTaskFind>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskFind"),
        QuestTaskType.ESCORT => JsonSerializer.Deserialize<QuestTaskEscort>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskEscort"),
        QuestTaskType.REACH_POSITION => JsonSerializer.Deserialize<QuestTaskReachPosition>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachPosition"),
        QuestTaskType.REACH_NPC => JsonSerializer.Deserialize<QuestTaskReachNPC>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachNPC"),
        _ => throw new JsonException("Unknown type"),
      };
    }

    throw new JsonException("Type property not found");
  }

  public override void Write(Utf8JsonWriter writer, SerializableQuestTask value, JsonSerializerOptions options)
  {
    // Determine the concrete type and serialize accordingly
    switch (value)
    {
      case QuestTaskCollection a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestTaskHunt a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestTaskFind a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestTaskEscort a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestTaskReachPosition a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestTaskReachNPC a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
