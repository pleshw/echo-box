namespace Game;

public class QuestTaskReachPosition : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_POSITION;
  public required string DestinationInfoFilePath;
}