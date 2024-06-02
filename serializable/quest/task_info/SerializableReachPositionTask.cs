using System.Numerics;
using Game;

namespace Serializable;

public class SerializableReachPositionTask : IReachPositionTaskComponent
{
  public TaskType TaskType { get; } = TaskType.REACH_POSITION;

  public required string Id { get; set; }

  public required string Title { get; set; }
  public required string Description { get; set; }
  public required Vector2 Size { get; set; }
  public required Vector2 TargetPosition { get; set; }
}