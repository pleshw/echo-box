namespace Quest;

public class QuestStepTaskEscort : ISerializableQuestStepTask
{
  public QuestStepTaskType TaskType { get; } = QuestStepTaskType.COLLECTION;
  public required string DestinationInfoFilePath;
  public required string NPCInfoFilePath;
}