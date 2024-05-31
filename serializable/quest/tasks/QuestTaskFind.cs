namespace Serializable;

public class QuestTaskFind : SerializableQuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.FIND;
  public required string ItemInfoFilePath;
}