using Game;
using Serializable;
using System.Numerics;

namespace Tests;

public static class QuestTests
{
  public static readonly SerializableCollectTask SerializableCollectTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Collect Task",
    Description = "This is a Task where you have to Collect items.",
    TargetItem = ItemTests.SerializableAllUsesItem,
    Amount = 3,
  };

  public static readonly SerializableEscortTask SerializableEscortTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Escort Task",
    Description = "This is a Task where you have to Escort a companion.",
    TargetPosition = Vector2.One * 3,
    Size = (Vector2.One * 30) with { X = 3 },
    Companion = EntityTests.CompanionActor
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
    Description = "This is a Task where you have to Defeat an amount of Entity.",
    TargetEntity = EntityTests.TargetActor,
    Amount = 3
  };

  public static readonly SerializableReachEntityTask SerializableReachEntityTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Reach Entity Task",
    Description = "This is a Task where you have to Reach an Entity.",
    TargetEntity = EntityTests.TargetActor,
    TargetDialogue = DialogueTests.DialogueComponentWithoutContinuation
  };

  public static readonly SerializableReachPositionTask SerializableReachPositionTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Reach Position Task",
    Description = "This is a Task where you have to Reach a Position.",
    TargetPosition = Vector2.One * 3,
    Size = (Vector2.One * 30) with { X = 3 },
  };

  public static readonly SerializableQuest SerializableQuestAllTasks = new()
  {
    Id = Guid.NewGuid(),
    Title = "Preparing",
    Description = "Learn all step types of quest",
    Tasks = [SerializableCollectTask, SerializableEscortTask, SerializableFindTask, SerializableHuntTask, SerializableReachEntityTask, SerializableReachPositionTask]
  };

  public static void TestMakeCompleteQuest()
  {
    FileController.CreateProjectFile(
          new ProjectFileInfo<SerializableQuest>()
          {
            FolderPath = "quest/test/",
            FileName = SerializableQuestAllTasks.Id.ToString() + ".json",
            FileData = SerializableQuestAllTasks
          }
    );
  }
}