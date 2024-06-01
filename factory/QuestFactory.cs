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
      new SerializableQuestTask (){
        Id = "Collection",
        Title = "Collection",
        Description = "Collection test quest.",
        TaskInfo = new SerializableQuestTaskCollection()
        {
          AmountToComplete = 10,
          ItemInfoFilePath = "res://data/test/quest/collection/test_item.json"
        }
      },
      new SerializableQuestTask (){
        Id = "Escort",
        Title = "Escort",
        Description = "Escort test quest.",
        TaskInfo = new SerializableQuestTaskEscort()
        {
          DestinationInfoFilePath = "res://data/test/quest/escort/destination.json",
          EntityInfoFilePath = "res://data/test/quest/test_npc.json"
        }
      },
      new SerializableQuestTask (){
        Id = "Find",
        Title = "Find",
        Description = "Find test quest.",
        TaskInfo = new SerializableQuestTaskFind()
        {
          ItemInfoFilePath = "res://data/test/quest/collection/test_hidden_item.json"
        }
      },
      new SerializableQuestTask (){
        Id = "Hunt",
        Title = "Hunt",
        Description = "Hunt test quest.",
        TaskInfo = new SerializableQuestTaskHunt()
        {
          AmountToComplete = 10,
          EntityInfoFilePath = "res://data/test/quest/test_npc_enemy.json"
        }
      },
      new SerializableQuestTask (){
        Id = "ReachNPC",
        Title = "ReachNPC",
        Description = "ReachNPC test quest.",
        TaskInfo = new SerializableQuestTaskReachEntity()
        {
          EntityInfoFilePath = "res://data/test/quest/test_npc.json",
          DialogueIdCompleteQuest = "Complete quest ReachNPC"
        }
      },
      new SerializableQuestTask (){
        Id = "ReachPosition",
        Title = "ReachPosition",
        Description = "ReachPosition test quest.",
        TaskInfo = new SerializableQuestTaskReachPosition()
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