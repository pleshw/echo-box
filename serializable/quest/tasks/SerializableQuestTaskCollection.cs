using Game;

namespace Serializable;

public class SerializableQuestTaskCollection : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.COLLECTION;
  public required int AmountToComplete;
  public required string ItemInfoFilePath;
}