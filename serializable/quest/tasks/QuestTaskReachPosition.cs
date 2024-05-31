namespace Serializable;

public class QuestTaskReachPosition : SerializableQuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_POSITION;
  public required string DestinationInfoFilePath;
}