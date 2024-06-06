using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;
using Tests;


namespace JSONConverters;

public class JsonQuestDialogueConverter : JsonConverter<QuestDialogueComponent>
{
  public override QuestDialogueComponent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    using JsonDocument doc = JsonDocument.ParseValue(ref reader);
    JsonElement root = doc.RootElement;

    if (!root.TryGetProperty("id", out JsonElement jsonDialogueId))
    {
      throw new JsonException("Invalid dialogue. Dialogue does not contain a valid Id.");
    }

    Guid dialogueId = jsonDialogueId.GetGuid();

    // Determine the concrete type from the JSON data
    if (root.TryGetProperty("quest", out JsonElement jsonQuest))
    {
      jsonQuest.TryGetProperty("id", out JsonElement jsonQuestId);
      Guid questId = jsonQuestId.GetGuid();

      QuestComponent dialogueQuest = QuestTests.GetQuestById(questId);

      DialogueComponent componentDialogue = JsonSerializer.Deserialize(doc.RootElement.GetRawText(), typeof(DialogueComponent), options) as DialogueComponent ?? throw new JsonException($"Invalid Conversion for quest dialogue: {dialogueId}");
      return new QuestDialogueComponent
      {
        Id = componentDialogue.Id,
        Options = componentDialogue.Options,
        Title = componentDialogue.Title,
        Content = componentDialogue.Content,
        AlreadyCompleted = componentDialogue.AlreadyCompleted,
        IsReadyToComplete = componentDialogue.IsReadyToComplete,
        Quest = dialogueQuest,
        IsHidden = false
      };
    }

    throw new JsonException($"'quest' property not found on \n{root.GetRawText()}");
  }

  public override void Write(Utf8JsonWriter writer, QuestDialogueComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();

    var propertiesNotIgnored = value.GetType()
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
      JsonSerializer.Serialize(writer, prop.GetValue(value), prop.PropertyType, options);
    }

    writer.WriteEndObject();
  }
}
