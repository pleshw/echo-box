using Game;

namespace Serializable;

public class SerializableAssignedHuntTask : IAssignedHuntTaskComponent
{
  public TaskType TaskType { get; } = TaskType.HUNT;

  public required GameEntity TargetEntity { get; set; }

  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required int Amount { get; set; }

  public required int AmountKilled { get; set; }

  public required GameEntity AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  public bool IsReadyToComplete
  {
    get
    {
      return AmountKilled >= Amount;
    }
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}