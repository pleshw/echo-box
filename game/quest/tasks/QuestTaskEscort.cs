namespace Game;

public class QuestTaskEscort : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.ESCORT;
  public required string DestinationInfoFilePath;
  public required string NPCInfoFilePath;
}