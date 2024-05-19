namespace Quest;

public class QuestStepTaskReachPosition : ISerializableQuestStepTask
{
  public QuestStepTaskType TaskType { get; } = QuestStepTaskType.COLLECTION;
  public required string DestinationInfoFilePath;
}