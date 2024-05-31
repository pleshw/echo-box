namespace Serializable;

public interface INPCDialogManager
{
  public SerializableDialogue DialogTree { get; set; }

  public List<SerializableDialogueNode> DialogueNodes { get; set; }

  public Dictionary<string, SerializableQuest> QuestsById { get; set; }
}