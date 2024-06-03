using System.Numerics;
using Game;

namespace Serializable;

public record class SerializableAssignedReachPositionTask : IAssignedReachPositionTaskComponent
{
  public TaskType TaskType { get; } = TaskType.REACH_POSITION;

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required Vector2 Size { get; set; }

  public required Vector2 TargetPosition { get; set; }

  public required GameEntity AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  public bool IsReadyToComplete
  {
    get
    {
      bool isAssignedInsideTheArea = true;
      return isAssignedInsideTheArea;
    }
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}