using System.Text.Json;
using System.Text.Json.Serialization;
using Game;

namespace JSONConverters;

public class JsonQuestConverter : JsonConverter<IQuestComponent>
{
  public override IQuestComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    if (!root.TryGetProperty("id", out JsonElement jsonQuestId))
    {
      throw new JsonException("Invalid dialogue. Dialogue does not contain a valid Id.");
    }

    Guid questId = jsonQuestId.GetGuid();
    return QuestTests.GetQuestById(questId);
  }

  public override void Write(Utf8JsonWriter writer, IQuestComponent value, JsonSerializerOptions options)
  {
    /// O switch tem que ir da classe principal para a base
    switch (value)
    {
      case AssignedQuestComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
