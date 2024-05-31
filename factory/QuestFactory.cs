using Serializable;
using System.Diagnostics.CodeAnalysis;

namespace Factory;


[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static class QuestFactory
{
  public static void TestMakeCompleteQuest()
  {
    SerializableQuest quest = new()
    {
      Id = "Quest Test all steps",
      Title = "Preparing",
      Description = "Learn all step types of quest",
      SubQuests = [
      new SerializableSubQuest (){
        Id = "Collection",
        Title = "Collection",
        Description = "Collection test quest.",
        IsCompleted = false,
        Task = new QuestTaskCollection()
        {
          AmountToComplete = 10,
          ItemInfoFilePath = "res://data/test/quest/collection/test_item.json"
        }
      },
      new SerializableSubQuest (){
        Id = "Escort",
        Title = "Escort",
        Description = "Escort test quest.",
        IsCompleted = false,
        Task = new QuestTaskEscort()
        {
          DestinationInfoFilePath = "res://data/test/quest/escort/destination.json",
          NPCInfoFilePath = "res://data/test/quest/test_npc.json"
        }
      },
      new SerializableSubQuest (){
        Id = "Find",
        Title = "Find",
        Description = "Find test quest.",
        IsCompleted = false,
        Task = new QuestTaskFind()
        {
          ItemInfoFilePath = "res://data/test/quest/collection/test_hidden_item.json"
        }
      },
      new SerializableSubQuest (){
        Id = "Hunt",
        Title = "Hunt",
        Description = "Hunt test quest.",
        IsCompleted = false,
        Task = new QuestTaskHunt()
        {
          AmountToComplete = 10,
          NPCInfoFilePath = "res://data/test/quest/test_npc_enemy.json"
        }
      },
      new SerializableSubQuest (){
        Id = "ReachNPC",
        Title = "ReachNPC",
        Description = "ReachNPC test quest.",
        IsCompleted = false,
        Task = new QuestTaskReachNPC()
        {
          NPCInfoFilePath = "res://data/test/quest/test_npc.json"
        }
      },
      new SerializableSubQuest (){
        Id = "ReachPosition",
        Title = "ReachPosition",
        Description = "ReachPosition test quest.",
        IsCompleted = false,
        Task = new QuestTaskReachPosition()
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