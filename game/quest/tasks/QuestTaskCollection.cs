namespace Game;

public class QuestTaskCollection : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.COLLECTION;
  public required int AmountToComplete;
  public required string ItemInfoFilePath;
}