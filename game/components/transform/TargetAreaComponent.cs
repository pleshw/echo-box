using System.Numerics;

namespace Game;

public class TargetAreaComponent : ITargetAreaComponent
{
  public required Vector2 Size { get; set; }
  public required Vector2 TargetPosition { get; set; }
}