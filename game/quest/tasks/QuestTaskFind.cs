using Serializable;

namespace Game;

public class QuestTaskFind(Entity assignedTo) : QuestTaskInfo(assignedTo)
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.FIND;

  public ItemInfo ItemInfo;

  public override bool IsReadyToComplete
  {
    get
    {
      return AssignedTo.Inventory.Has(ItemInfo.Id);
    }
  }

  public override void Complete()
  {

  }
}