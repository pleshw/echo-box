using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serializable;
using Game;


namespace AOT;

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public class JsonQuestTaskConverter : JsonConverter<QuestTask>
{
  public override QuestTask Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
        QuestTaskType.COLLECTION => JsonSerializer.Deserialize<SerializableQuestTaskCollection>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskCollection"),
        QuestTaskType.HUNT => JsonSerializer.Deserialize<SerializableQuestTaskHunt>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskHunt"),
        QuestTaskType.FIND => JsonSerializer.Deserialize<SerializableQuestTaskFind>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskFind"),
        QuestTaskType.ESCORT => JsonSerializer.Deserialize<SerializableQuestTaskEscort>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskEscort"),
        QuestTaskType.REACH_POSITION => JsonSerializer.Deserialize<SerializableQuestTaskReachPosition>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachPosition"),
        QuestTaskType.REACH_NPC => JsonSerializer.Deserialize<SerializableQuestTaskReachNPC>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachNPC"),
        _ => throw new JsonException("Unknown type"),
      };
    }

    throw new JsonException("Type property not found");
  }

  public override void Write(Utf8JsonWriter writer, QuestTask value, JsonSerializerOptions options)
  {
    // Determine the concrete type and serialize accordingly
    switch (value)
    {
      case SerializableQuestTaskCollection a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableQuestTaskHunt a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableQuestTaskFind a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableQuestTaskEscort a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableQuestTaskReachPosition a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableQuestTaskReachNPC a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
