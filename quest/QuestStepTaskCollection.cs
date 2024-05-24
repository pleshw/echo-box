namespace Quest;

public class QuestStepTaskCollection : SerializableQuestStepTask
{
  public override QuestStepTaskType TaskType { get; } = QuestStepTaskType.COLLECTION;
  public required int AmountToComplete;
  public required string ItemInfoFilePath;
}