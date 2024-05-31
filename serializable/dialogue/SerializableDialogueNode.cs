namespace Serializable;

public record class SerializableDialogueNode
{

  public required string FolderPath;

  public required string FileName;


  public SerializableDialogueRestrictions? Restrictions;


  /// <summary>
  /// The message that is shown on dialog window
  /// </summary>
  public required string Message;


  public required List<string> SpeakersNodeNames;


  public required List<string> ListenersNodeNames;


  public required List<SerializableDialogueOption> Options;


  public required List<SerializableQuest> QuestsEnabledOnComplete;
}