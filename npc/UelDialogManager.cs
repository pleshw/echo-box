using Dialogue;
using Quest;

namespace NPC;

public class UelDialogManager : INPCDialogManager
{
  public SerializableDialogue DialogTree { get; set; }
  public List<SerializableDialogueNode> DialogueNodes { get; set; }
  public Dictionary<string, SerializableQuest> QuestsById { get; set; } = new()
  {
    ["HideInBushes"] = new SerializableQuest
    {
      Id = "HideInBushes",
      Title = "Hide in bushes",
      Description = "Hide in bushes to attack without being noticed. Go there and get me some scared slimes.",
      QuestSteps = [],
    }
  };
}