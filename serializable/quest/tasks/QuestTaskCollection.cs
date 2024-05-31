namespace Serializable;

public class QuestTaskCollection : SerializableQuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.COLLECTION;
  public required int AmountToComplete;
  public required string ItemInfoFilePath;
}