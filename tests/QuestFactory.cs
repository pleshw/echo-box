using Serializable;

namespace Factory;

public static class QuestFactory
{
  public static void TestMakeCompleteQuest()
  {
    SerializableQuest quest = new()
    {
      Id = "Quest Test all steps",
      Title = "Preparing",
      Description = "Learn all step types of quest",
      Tasks = []
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