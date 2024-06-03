using System.Numerics;
using Game;

namespace Serializable;

public record class SerializableEscortTask : IEscortTaskComponent
{
  public TaskType TaskType { get; } = TaskType.ESCORT;

  public required GameEntity Companion { get; set; }

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required Vector2 TargetPosition { get; set; }

  public required Vector2 Size { get; set; }
}