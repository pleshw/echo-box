using Game;
using Serializable;
using System.Numerics;

namespace Tests;

public static class QuestTests
{
  public static readonly GameEntity CompanionActor = new PlayerEntity(Guid.NewGuid());

  public static readonly SerializableCollectTask SerializableCollectTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Collect Task",
    Description = "This is a Task where you have to Collect items.",
    TargetItem = ItemTests.SerializableAllUsesItem,
    Amount = 10,
  };

  public static readonly SerializableEscortTask SerializableEscortTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Escort Task",
    Description = "This is a Task where you have to Escort a companion.",
    TargetPosition = Vector2.One * 2,
    Size = Vector2.One * 10,
    Companion = CompanionActor
  };

  public static readonly SerializableFindTask SerializableFindTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Find Task",
    Description = "This is a Task where you have to Find an item.",
    TargetItem = ItemTests.SerializableAllUsesItem
  };

  public static readonly SerializableHuntTask SerializableHuntTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Hunt Task",
    Description = "This is a Task where you have to Hunt a Entity.",
    TargetEntity = ItemTests.SerializableAllUsesItem
  };

  public static readonly SerializableQuest SerializableQuestAllTasks = new()
  {
    Id = Guid.NewGuid(),
    Title = "Preparing",
    Description = "Learn all step types of quest",
    Tasks = [SerializableCollectTask, SerializableEscortTask, SerializableFindTask,]
  };

  public static void TestMakeCompleteQuest()
  {
    FileController.CreateProjectFile(
          new ProjectFileInfo<SerializableQuest>()
          {
            FolderPath = "quest/test/",
            FileName = "test_quest.json",
            FileData = SerializableQuestAllTasks
          }
    );
  }
}