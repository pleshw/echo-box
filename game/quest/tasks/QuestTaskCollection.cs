using Serializable;

namespace Game;

public class QuestTaskCollection(Entity assignedTo) : QuestTaskInfo(assignedTo)
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.COLLECTION;

  public int AmountToComplete;

  public ItemInfo ItemInfo;

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

  }
}