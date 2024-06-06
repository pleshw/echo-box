using Game;
using System.Numerics;

namespace Tests;

public static class QuestTests
{
  public static readonly CollectTaskComponent SerializableCollectTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Collect Task",
    Description = "This is a Task where you have to Collect items.",
    TargetItem = ItemTests.SerializableAllUsesItem,
    Amount = 3,
  };

  public static readonly EscortTaskComponent SerializableEscortTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Escort Task",
    Description = "This is a Task where you have to Escort a companion.",
    TargetPosition = Vector2.One * 3,
    Size = (Vector2.One * 30) with { X = 3 },
    Companion = EntityTests.CompanionActor
  };

  public static readonly FindTaskComponent SerializableFindTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Find Task",
    Description = "This is a Task where you have to Find an item.",
    TargetItem = ItemTests.SerializableAllUsesItem
  };

  public static readonly HuntTaskComponent SerializableHuntTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Hunt Task",
    Description = "This is a Task where you have to Defeat an amount of Entity.",
    TargetEntity = EntityTests.TargetActor,
    Amount = 3
  };

  public static readonly ReachEntityTaskComponent SerializableReachEntityTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Reach Entity Task",
    Description = "This is a Task where you have to Reach an Entity.",
    TargetEntity = EntityTests.TargetActor,
    TargetDialogue = DialogueTests.DialogueComponentWithoutContinuation
  };

  public static readonly ReachPositionTaskComponent SerializableReachPositionTask = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test - Serializable Reach Position Task",
    Description = "This is a Task where you have to Reach a Position.",
    TargetPosition = Vector2.One * 3,
    Size = (Vector2.One * 30) with { X = 3 },
  };

  public static readonly QuestComponent SerializableQuestAllTasks = new()
  {
    Id = new Guid("ff525de8-5ea8-46e5-9518-963c74a09faf"),
    Title = "Preparing",
    Description = "Learn all step types of quest",
    Tasks = [SerializableCollectTask, SerializableEscortTask, SerializableFindTask, SerializableHuntTask, SerializableReachEntityTask, SerializableReachPositionTask]
  };

  public static readonly QuestComponent SerializableQuestCollectSomethings = new()
  {
    Id = new Guid("cf96482a-3bc8-46fa-b30f-1fc6d41aca4f"),
    Title = "Preparing",
    Description = "Learn all step types of quest",
    Tasks = [
      SerializableCollectTask,
       new CollectTaskComponent()
        {
          Id = Guid.NewGuid(),
          Title = "Test - Instantiated Task",
          Description = "This is a Task where you have to Collect accessories.",
          TargetItem = ItemTests.SerializableAccessoryItem,
          Amount = 3,
        }
  ]
  };

  public static readonly List<QuestComponent> AllQuests = [SerializableQuestAllTasks, SerializableQuestCollectSomethings];

  public static void TestRemakeAllQuests()
  {
    FileController.CreateProjectFile(
          new ProjectFileInfo<QuestComponent>()
          {
            FolderPath = "quest/test/",
            FileName = SerializableQuestAllTasks.Id.ToString() + ".json",
            FileData = SerializableQuestAllTasks
          }
    );
  }


  public static QuestComponent GetQuestById(Guid questId)
  {
    return AllQuests.Where(q => q.Id == questId).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Quest {questId} does not exist.");
  }
}