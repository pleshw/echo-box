using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Serializable;
using Game;


namespace JSONConverters;

public class JsonTaskConverter : JsonConverter<ITaskComponent>
{
  public override ITaskComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    // Read the JSON document
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    // Determine the concrete type from the JSON data
    if (root.TryGetProperty("taskType", out JsonElement typeElement))
    {
      int? type = typeElement.GetInt32();
      string rootText = root.GetRawText();

      return (TaskType)type switch
      {
        TaskType.COLLECT => JsonSerializer.Deserialize<SerializableCollectTask>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskCollection"),
        TaskType.HUNT => JsonSerializer.Deserialize<SerializableHuntTask>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskHunt"),
        TaskType.FIND => JsonSerializer.Deserialize<SerializableFindTask>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskFind"),
        TaskType.ESCORT => JsonSerializer.Deserialize<SerializableEscortTask>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskEscort"),
        TaskType.REACH_POSITION => JsonSerializer.Deserialize<SerializableReachPositionTask>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachPosition"),
        TaskType.REACH_ENTITY => JsonSerializer.Deserialize<SerializableReachEntityTask>(rootText, options) ?? throw new JsonException("Failed to convert for type QuestStepTaskReachNPC"),
        _ => throw new JsonException("Unknown type"),
      };
    }

    throw new JsonException("Type property not found");
  }

  public override void Write(Utf8JsonWriter writer, ITaskComponent value, JsonSerializerOptions options)
  {
    // Determine the concrete type and serialize accordingly
    switch (value)
    {
      case SerializableCollectTask a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableHuntTask a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableFindTask a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableEscortTask a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableReachPositionTask a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case SerializableReachEntityTask a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
