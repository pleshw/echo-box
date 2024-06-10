using Game;

namespace Tests;


public static class StageTests
{
  public static readonly StageComponent SimpleStage = new()
  {
    UniqueName = "TestStage",
    EntityList = [.. EntityTests.AllEntities]
  };

  public static readonly List<IStageComponent> AllStages = [SimpleStage];

  public static void TestRemakeAllStages()
  {
    AllStages.ForEach(q => FileController.CreateProjectFile(
        new ProjectFileInfo<IStageComponent>()
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
          ).ToList();
  }
}