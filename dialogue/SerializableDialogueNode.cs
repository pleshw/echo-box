using System.Text.Json.Serialization;
using Quest;

namespace Dialogue;

public record class SerializableDialogueNode
{

  public required string NodePath;


  public SerializableDialogueRestrictions? Restrictions;


  public required string Message;


  public required List<string> SpeakersNodeNames;


  public required List<string> ListenersNodeNames;


  public required List<SerializableDialogueOption> Options;


  public required List<SerializableQuest> QuestsEnabledOnComplete;
}