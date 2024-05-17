using System.Text.Json.Serialization;
using Quest;

namespace Dialogue;

public record class SerializableDialogueNode
{
  [JsonInclude]
  public required string NodePath;

  [JsonInclude]
  public SerializableDialogueRestrictions? Restrictions;

  [JsonInclude]
  public required string Message;

  [JsonInclude]
  public required List<string> SpeakersNodeNames;

  [JsonInclude]
  public required List<string> ListenersNodeNames;

  [JsonInclude]
  public required List<SerializableDialogueOption> Options;

  [JsonInclude]
  public required List<SerializableQuest> QuestsEnabledOnComplete;
}