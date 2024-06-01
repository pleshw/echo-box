namespace Serializable;

public class SerializableQuestTaskReachPosition : SerializableQuestTaskInfo
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_POSITION;
  
  public required string DestinationInfoFilePath;
}