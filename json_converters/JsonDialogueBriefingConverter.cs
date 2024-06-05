using System.Text.Json;
using System.Text.Json.Serialization;
using Game;
using Tests;


namespace JSONConverters;

public class JsonDialogueBriefingConverter : JsonConverter<IDialogueBriefingComponent>
{
  public override IDialogueBriefingComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    if (!root.TryGetProperty("id", out JsonElement jsonDialogueId))
    {
      throw new JsonException("Invalid dialogue. Dialogue does not contain a valid Id.");
    }

    Guid dialogueId = jsonDialogueId.GetGuid();

    return new DialogueBriefingComponent
    {
      Id = dialogueId,
      Title = root.GetProperty("title").GetString() ?? throw new JsonException($"Invalid title for dialogue {dialogueId}"),
      Dialogue = DialogueTests.GetDialogueById(dialogueId)
    };
  }

  public override void Write(Utf8JsonWriter writer, IDialogueBriefingComponent value, JsonSerializerOptions options)
  {
    JsonSerializer.Serialize(writer, value as DialogueBriefingComponent, options);
  }
}
