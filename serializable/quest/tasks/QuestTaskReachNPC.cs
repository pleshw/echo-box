namespace Serializable;

public class QuestTaskReachNPC : SerializableQuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_NPC;
  public required string NPCInfoFilePath;
}