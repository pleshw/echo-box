using System.Numerics;
using Game;

namespace Build;

public class AliceHouseOutsideBuild : StageBuild<StageComponent>
{
  private StageComponent? _stage;

  public List<IGatherComponent> GatherList = [];

  public override StageComponent Stage
  {
    get
    {
      return _stage ??= new()
      {
        UniqueName = "AliceHouseOutside",
        GatherList = GatherList,
        GridMap = new GridMapComponent()
        {
          GridCells = Enumerable.Range(0, 100)
                          .Select(i => new GridCellImageComponent
                          {
                            CellStageSprite = new DisplayImageComponent { DisplayImage = "test/image/filepath/OriginalCellStageSprite" },
                            CellMinimapSprite = new DisplayImageComponent { DisplayImage = "test/image/filepath/OriginalCellMinimapSprite" },
                            Position = new(i % 10, i / 10),
                            Size = new(3, 3),
                            Index = i,
                            Status = (GridCellStatus)(1 << (i % 6))
                          } as IGridCellComponent)
                          .ToList(),
          Width = 10,
          Height = 10
        },
      };
    }
  }
}