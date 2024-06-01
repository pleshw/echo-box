using Serializable;

namespace Game;

public class QuestTaskReachPosition(Entity assignedTo) : QuestTaskInfo(assignedTo)
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_POSITION;

  public DestinationInfo DestinationInfo;

  public override bool IsReadyToComplete
  {
    get
    {
      return DestinationInfo.Rect2.Abs().HasPoint(AssignedTo.Position) && AssignedTo.IsAlive;
    }
  }

  public override void Complete()
  {

  }
}