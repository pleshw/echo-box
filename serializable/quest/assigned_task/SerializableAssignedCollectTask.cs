using Game;

namespace Serializable;

public record class SerializableAssignedCollectTask : IAssignedCollectTaskComponent
{
  public TaskType TaskType { get; } = TaskType.COLLECT;

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required IItemComponent TargetItem { get; set; }

  public required int Amount { get; set; }

  public required GameEntity AssignedTo { get; set; }
  public required DateTime StartedAt { get; set; }

  public bool IsReadyToComplete
  {
    get
    {
      return AmountCollected >= Amount;
    }
  }

  public required int AmountCollected { get; set; }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}