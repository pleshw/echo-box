namespace Serializable;

public class SerializableQuestTaskHunt : SerializableQuestTaskInfo
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.HUNT;

  public required int AmountToComplete;

  public required string EntityInfoFilePath;
}