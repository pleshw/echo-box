using System.Numerics;

namespace Game;

public class PositionComponent : IPositionComponent
{
  public required Vector2 Position { get; set; }
}