namespace Serializable;

public class SerializableQuestTaskCollection : SerializableQuestTaskInfo
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.COLLECTION;

  public required int AmountToComplete;

  public required string ItemInfoFilePath;
}