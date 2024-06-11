using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

[JsonConverter(typeof(JsonGridMapConverter))]
public class GridMapComponent : IGridMapComponent
{
  public required List<IGridCellComponent> GridCells { get; set; }

  public required int Width { get; set; }

  public required int Height { get; set; }

  public object Clone()
  {
    List<IGridCellComponent> clonedGridCells = [];

    foreach (var cell in GridCells)
    {
      clonedGridCells.Add((IGridCellComponent)cell.Clone());
    }

    return new GridMapComponent()
    {
      GridCells = clonedGridCells,
      Width = Width,
      Height = Height
    };
  }
}