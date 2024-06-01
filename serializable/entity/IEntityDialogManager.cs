namespace Serializable;

public interface IEntityDialogManager
{
  public SerializableDialogue DialogTree { get; set; }

  public List<SerializableDialogueNode> DialogueNodes { get; set; }

  public Dictionary<string, SerializableQuest> QuestsById { get; set; }
}