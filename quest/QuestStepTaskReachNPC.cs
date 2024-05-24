namespace Quest;

public class QuestStepTaskReachNPC : SerializableQuestStepTask
{
  public override QuestStepTaskType TaskType { get; } = QuestStepTaskType.REACH_NPC;
  public required string NPCInfoFilePath;
}