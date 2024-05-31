using Game;

namespace Serializable;

public class SerializableQuestTaskReachPosition : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_POSITION;
  public required string DestinationInfoFilePath;
}