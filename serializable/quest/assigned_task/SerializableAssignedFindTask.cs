using Game;

namespace Serializable;

public record class SerializableAssignedFindTask : IAssignedFindTaskComponent
{
  public TaskType TaskType { get; } = TaskType.FIND;

  public required IItemComponent TargetItem { get; set; }

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required GameEntity AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }


  public required int AmountCollected { get; set; }

  public bool IsReadyToComplete
  {
    get
    {
      return AmountCollected > 0;
    }
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}