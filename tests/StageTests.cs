using System.Numerics;
using Game;

namespace Game;


public static class StageTests
{
  public static readonly ItemComponent TestOreItem = new()
  {
    ItemType = ItemTypes.ORE,
    DisplayName = "Test Ore",
    UniqueName = "Test Ore",
    RequiredLevel = 0,
    Description = "A Weapon for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly StageComponent SimpleStage = new()
  {
    UniqueName = "TestStage",
    GatherList = [
      new GatherComponent
      {
        UniqueName = "TestOre",
        RequiredLevel = 0,
        Resource = TestOreItem,
        TimeToRenew = 100,
        CompletedAt = DateTime.Now,
        Amount = 10,
        TotalProgress = 10,
        CurrentProgress = 0,
        Position = Vector2.Zero,
        LevelByRequiredMastery = new()
        {
          {MasteryTypes.GATHERING, 10}
        }
      }
    ],
    GridMap = new GridMapComponent()
    {
      GridCells = Enumerable.Range(0, 100)
                          .Select(i => new GridCellComponent
                          {
                            Position = new(i % 10, i / 10),
                            Size = new(3, 3),
                            Index = i,
                            Status = (GridCellStatus)((i % 7) << 1)
                          } as IGridCellComponent)
                          .ToList(),
      Width = 10,
      Height = 10
    },
  };

  public static readonly List<StageComponent> AllStages = [SimpleStage];

  public static void TestRemakeAllStages()
  {
    AllStages.ForEach(q => FileController.CreateProjectFile(
        new ProjectFileInfo<StageComponent>()
        {
          FolderPath = "stage/test/",
          FileName = q.UniqueName + ".json",
          FileData = q
        }
    ));
  }

  public static IStageComponent GetStageByUniqueName(string uniqueName)
  {
    return AllStages.Where(q => q.UniqueName == uniqueName).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Entity {uniqueName} does not exist.");
  }

  public static List<IStageComponent> GetStagesByUniqueName(List<IUniqueNameComponent> uniqueNames)
  {
    return GetStagesByUniqueName(uniqueNames.Select(u => u.UniqueName).ToList());
  }

  public static List<IStageComponent> GetStagesByUniqueName(List<string> uniqueNames)
  {
    return uniqueNames.Select(uniqueName =>
              AllStages.FirstOrDefault(q => q.UniqueName == uniqueName)
              ?? throw new Exception($"Invalid deserialization. Entity {uniqueName} does not exist.")
          )
          .Cast<IStageComponent>()
          .ToList();
  }
}