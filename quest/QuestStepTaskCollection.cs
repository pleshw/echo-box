namespace Quest;

public class QuestStepTaskCollection : ISerializableQuestStepTask
{
  public QuestStepTaskType TaskType { get; } = QuestStepTaskType.COLLECTION;
  public required int AmountToComplete;
  public required string ItemInfoFilePath;
}