using Game;

namespace Game;

public static class MenuTests
{
  public static readonly CollectTaskComponent SerializableCollectTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Collect Task",
    Description = "This is a Task where you have to Collect items.",
    TargetItem = ItemTests.SerializableAllUsesItem,
    Amount = 3,
  };

  public static void TestMakeMenu()
  {
    // FileController.CreateProjectFile(
    //       new ProjectFileInfo<SerializableQuest>()
    //       {
    //         FolderPath = "quest/test/",
    //         FileName = SerializableQuestAllTasks.Id.ToString() + ".json",
    //         FileData = SerializableQuestAllTasks
    //       }
    // );
  }
}