using System.Numerics;
using Game;

namespace Serializable;

public class SerializableEscortTask : IEscortTaskComponent
{
  public TaskType TaskType { get; } = TaskType.ESCORT;

  public required GameEntity Companion { get; set; }

  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required Vector2 TargetPosition { get; set; }
}