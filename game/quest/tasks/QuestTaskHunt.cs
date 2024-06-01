using Serializable;

namespace Game;

public class QuestTaskHunt(Entity assignedTo) : QuestTaskInfo(assignedTo)
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.HUNT;

  public int AmountToComplete;

  public EntityInfo EntityInfo;

  public override bool IsReadyToComplete
  {
    get
    {
      return AmountGathered >= AmountToComplete;
    }
  }

  public int AmountGathered { get; }

  public override void Complete()
  {
    throw new NotImplementedException();
  }
}