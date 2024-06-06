using System.Numerics;

namespace Game;

public record class ReachPositionTaskComponent : IReachPositionTaskComponent
{
  public TaskType TaskType { get; } = TaskType.REACH_POSITION;

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required Vector2 Size { get; set; }

  public required Vector2 TargetPosition { get; set; }
}