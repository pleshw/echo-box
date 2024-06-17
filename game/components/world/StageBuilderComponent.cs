using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class StageBuilderComponent : StageComponent
{
  public void ReplaceArea(ITargetAreaComponent targetArea, GridCellStatus cellStatus)
  {
    var offsetPosition = targetArea.TargetPosition;
    var areaSize = targetArea.Size;
    for (int i = 0; i < areaSize.X; ++i)
    {
      for (int j = 0; j < areaSize.Y; ++j)
      {
        GridMapComponent.Cell((int)(i + offsetPosition.X), (int)(j + offsetPosition.Y), cellStatus);
      }
    }
  }

  public void ReplaceArea(IPositionComponent positionComponent, GridMapComponent gridMapShape)
  {
    var offsetPosition = positionComponent.Position;
    for (int i = 0; i < gridMapShape.Width; ++i)
    {
      for (int j = 0; j < gridMapShape.Height; ++j)
      {
        GridMapComponent.Cell((int)(i + offsetPosition.X), (int)(j + offsetPosition.Y), gridMapShape.Cell(i, j));
      }
    }
  }

  public void ChangeStatus(ITargetAreaComponent targetArea, GridCellStatus status)
  {

  }

  public void ChangeStatus(int x, int y, GridCellStatus status)
  {

  }
}