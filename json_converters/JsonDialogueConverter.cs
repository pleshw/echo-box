using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


namespace JSONConverters;

public class JsonDialogueConverter : JsonConverter<IDialogueComponent>
{
  public override IDialogueComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    if (!root.TryGetProperty("id", out JsonElement jsonDialogueId))
    {
      throw new JsonException("Invalid dialogue. Dialogue does not contain a valid Id.");
    }

    Guid dialogueId = jsonDialogueId.GetGuid();
    return DialogueTests.GetDialogueById(dialogueId);
  }

  public override void Write(Utf8JsonWriter writer, IDialogueComponent value, JsonSerializerOptions options)
  {
    /// O switch tem que ir da classe principal para a base
    switch (value)
    {
      case MenuPortraitDialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestPortraitDialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case MenuDialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case QuestDialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case PortraitDialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case DialogueComponent a:
        JsonSerializer.Serialize(writer, a, options);
        break;
      case null:
        throw new JsonException("Value is null");
      default:
        throw new JsonException("Unknown type");
    }
  }
}
