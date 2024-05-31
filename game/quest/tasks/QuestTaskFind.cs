namespace Game;

public class QuestTaskFind : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.FIND;
  public required string ItemInfoFilePath;
}