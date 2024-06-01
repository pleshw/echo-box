namespace Serializable;

public class SerializableQuestTaskEscort : SerializableQuestTaskInfo
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.ESCORT;

  public required string DestinationInfoFilePath;

  public required string EntityInfoFilePath;
}