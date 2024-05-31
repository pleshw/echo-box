using Game;

namespace Serializable;

public class SerializableQuestTaskReachNPC : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_NPC;
  public required string NPCInfoFilePath;
}