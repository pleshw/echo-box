namespace Quest;

public class QuestStepTaskReachPosition : SerializableQuestStepTask
{
  public override QuestStepTaskType TaskType { get; } = QuestStepTaskType.REACH_POSITION;
  public required string DestinationInfoFilePath;
}