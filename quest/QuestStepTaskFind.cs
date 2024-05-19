namespace Quest;

public class QuestStepTaskFind : ISerializableQuestStepTask
{
  public QuestStepTaskType TaskType { get; } = QuestStepTaskType.COLLECTION;
  public required string ItemInfoFilePath;
}