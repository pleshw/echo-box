namespace Quest;

public class QuestStepTaskHunt : SerializableQuestStepTask
{
  public override QuestStepTaskType TaskType { get; } = QuestStepTaskType.HUNT;
  public required int AmountToComplete;
  public required string NPCInfoFilePath;
}