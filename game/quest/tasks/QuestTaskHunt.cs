namespace Game;

public class QuestTaskHunt : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.HUNT;
  public required int AmountToComplete;
  public required string NPCInfoFilePath;
}