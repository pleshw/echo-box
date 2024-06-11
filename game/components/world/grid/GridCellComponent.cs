using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

[JsonConverter(typeof(JsonGridCellConverter))]
public class GridCellComponent : IGridCellComponent
{
  public required Vector2 Position { get; set; }

  public required Vector2 Size { get; set; }

  public required int Index { get; set; }

  public object Clone()
  {
    return new GridCellComponent
    {
      Position = Position,
      Size = Size,
      Index = Index
    };
  }
}