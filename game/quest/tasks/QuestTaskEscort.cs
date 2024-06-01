using Serializable;

namespace Game;

public class QuestTaskEscort(Entity assignedTo) : QuestTaskInfo(assignedTo)
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.ESCORT;

  public DestinationInfo DestinationInfo;

  public EntityInfo EntityInfo;

  public override bool IsReadyToComplete
  {
    get
    {
      return DestinationInfo.Rect2.Abs().HasPoint(EntityInfo.Position) && AssignedTo.IsAlive;
    }
  }

  public override void Complete()
  {

  }
}