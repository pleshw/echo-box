namespace Serializable;

public class SerializableQuestTaskFind : SerializableQuestTaskInfo
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.FIND;

  public required string ItemInfoFilePath;
}