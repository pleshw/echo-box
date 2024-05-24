using Entity;
using Dialogue;
using static Entity.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Quest;

namespace Main;


[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static class QuestManager
{
  public static void TestMakeCompleteQuest()
  {
    SerializableQuest quest = new()
    {
      Id = "Quest Test all steps",
      Title = "Preparing",
      Description = "Learn all step types of quest",
      QuestSteps = [
      new SerializableQuestStep (){
        Id = "Collection",
        Title = "Collection",
        Description = "Collection test quest.",
        IsCompleted = false,
        Task = new QuestStepTaskCollection()
        {
          AmountToComplete = 10,
          ItemInfoFilePath = "res://data/test/quest/collection/test_item.json"
        }
      },
      new SerializableQuestStep (){
        Id = "Escort",
        Title = "Escort",
        Description = "Escort test quest.",
        IsCompleted = false,
        Task = new QuestStepTaskEscort()
        {
          DestinationInfoFilePath = "res://data/test/quest/escort/destination.json",
          NPCInfoFilePath = "res://data/test/quest/test_npc.json"
        }
      },
      new SerializableQuestStep (){
        Id = "Find",
        Title = "Find",
        Description = "Find test quest.",
        IsCompleted = false,
        Task = new QuestStepTaskFind()
        {
          ItemInfoFilePath = "res://data/test/quest/collection/test_hidden_item.json"
        }
      },
      new SerializableQuestStep (){
        Id = "Hunt",
        Title = "Hunt",
        Description = "Hunt test quest.",
        IsCompleted = false,
        Task = new QuestStepTaskHunt()
        {
          AmountToComplete = 10,
          NPCInfoFilePath = "res://data/test/quest/test_npc_enemy.json"
        }
      },
      new SerializableQuestStep (){
        Id = "ReachNPC",
        Title = "ReachNPC",
        Description = "ReachNPC test quest.",
        IsCompleted = false,
        Task = new QuestStepTaskReachNPC()
        {
          NPCInfoFilePath = "res://data/test/quest/test_npc.json"
        }
      },
      new SerializableQuestStep (){
        Id = "ReachPosition",
        Title = "ReachPosition",
        Description = "ReachPosition test quest.",
        IsCompleted = false,
        Task = new QuestStepTaskReachPosition()
        {
          DestinationInfoFilePath = "res://data/test/quest/escort/destination.json"
        }
      },
      ]
    };

    FileController.CreateProjectFile(
          new ProjectFileInfo<SerializableQuest>()
          {
            FolderPath = "quest/test/",
            FileName = "test_quest.json",
            FileData = quest
          }
    );
  }
}