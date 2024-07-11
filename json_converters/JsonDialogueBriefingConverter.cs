using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Game;


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
    return DialogueTests.GetDialogueById(dialogueId);
  }

  /// Write DialogueBriefingComponent exposed properties
  public override void Write(Utf8JsonWriter writer, IDialogueBriefingComponent value, JsonSerializerOptions options)
  {
    writer.WriteStartObject();
    writer.WriteString("type", value.GetType().AssemblyQualifiedName);

    IDialogueBriefingComponent valueAsBriefing = value;

    var propertiesNotIgnored = typeof(DialogueBriefingComponent)
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
      JsonSerializer.Serialize(writer, prop.GetValue(valueAsBriefing), prop.PropertyType, options);
    }

    writer.WriteEndObject();
  }
}
