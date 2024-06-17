using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class StageBuilderComponent : StageComponent
{
  public void ReplaceCells(IPositionComponent positionComponent, GridMapComponent gridMapShape)
  {

    /// TODO CUT AN AREA NOT A PART FROM A POSITION TO ANOTHER
    // var endPosition = new PositionComponent
    // {
    //   Position = new()
    //   {
    //     X = positionComponent.Position.X + gridMapShape.Width,
    //     Y = positionComponent.Position.Y + gridMapShape.Height
    //   }
    // };

    // GridMapComponent.ForEach(positionComponent, endPosition, (IGridCellComponent cell, int x, int y, int index, int count) =>
    // {
    //   cell.Copy(gridMapShape.GridCells[count]);
    // });
  }

  public void ChangeStatus(ITargetAreaComponent targetArea, GridCellStatus status)
  {

  }

  public void ChangeStatus(int x, int y, GridCellStatus status)
  {

  }
}