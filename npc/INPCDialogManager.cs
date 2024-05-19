using Dialogue;
using Quest;

namespace NPC;

public interface INPCDialogManager
{
  public SerializableDialogue DialogTree { get; set; }

  public List<SerializableDialogueNode> DialogueNodes { get; set; }

  public Dictionary<string, SerializableQuest> QuestsById { get; set; }
}