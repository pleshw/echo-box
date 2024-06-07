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

  public static readonly List<ITaskComponent> AllTasks = [SerializableCollectTask, SerializableEscortTask, SerializableFindTask, SerializableHuntTask, SerializableReachEntityTask, SerializableReachPositionTask];

  public static readonly QuestComponent SerializableQuestAllTasks = new()
  {
    Id = new Guid("ff525de8-5ea8-46e5-9518-963c74a09faf"),
    Title = "Preparing",
    Description = "Learn all step types of quest",
    Tasks = AllTasks
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

  public static readonly AssignedQuestComponent SerializableAssignedQuestAllTasks = new()
  {
    Id = new Guid("fd0503c7-fa8c-43aa-8e3a-e876c01648e0"),
    AssignedTo = EntityTests.PlayerActor,
    Title = "A Quest assigned to the player Actor",
    Description = "Learning all step types of quest",
    Tasks = [
      new AssignedCollectTaskComponent(SerializableCollectTask, EntityTests.PlayerActor, DateTime.Now),
      new AssignedEscortTaskComponent(SerializableEscortTask, EntityTests.PlayerActor, DateTime.Now),
      new AssignedFindTaskComponent(SerializableFindTask, EntityTests.PlayerActor, DateTime.Now),
      new AssignedHuntTaskComponent(SerializableHuntTask, EntityTests.PlayerActor, DateTime.Now),
      new AssignedReachEntityTaskComponent(SerializableReachEntityTask, EntityTests.PlayerActor, DateTime.Now),
      new AssignedReachPositionTaskComponent(SerializableReachPositionTask, EntityTests.PlayerActor, DateTime.Now),
    ]
  };

  public static readonly List<QuestComponent> AllQuests = [SerializableQuestAllTasks, SerializableQuestCollectSomethings];
  public static readonly List<AssignedQuestComponent> AllAssignedQuests = [SerializableAssignedQuestAllTasks];

  public static void TestRemakeAllQuests()
  {
    AllQuests.ForEach(q => FileController.CreateProjectFile(
          new ProjectFileInfo<IQuestComponent>()
          {
            FolderPath = "quest/test/",
            FileName = q.Id.ToString() + ".json",
            FileData = q
          }
    ));

    AllAssignedQuests.ForEach(q => FileController.CreateProjectFile(
          new ProjectFileInfo<IAssignedQuestComponent>()
          {
            FolderPath = "quest/test/",
            FileName = q.Id.ToString() + ".json",
            FileData = q
          }
    ));
  }


  public static QuestComponent GetQuestById(Guid questId)
  {
    return AllQuests.Where(q => q.Id == questId).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Quest {questId} does not exist.");
  }

  public static T GetQuestById<T>(Guid questId) where T : QuestComponent
  {
    return AllQuests.OfType<T>().Where(q => q.Id == questId).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Quest {questId} does not exist.");
  }

  public static T GetAssignedQuestById<T>(Guid questId) where T : AssignedQuestComponent
  {
    return AllAssignedQuests.OfType<T>().Where(q => q.Id == questId).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Quest {questId} does not exist.");
  }
}