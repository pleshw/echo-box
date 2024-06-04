using Game;
using Serializable;

namespace Tests;

public static class DialogueTests
{
  public static readonly DialogueComponent DialogueComponentWithoutContinuation = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test Dialogue Without Continuation",
    Content = "This is a test Dialogue without continuation.",
    Next = [],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
  };

  public static readonly QuestDialogueComponent DialogueComponentWithQuest = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test Dialogue With Quest",
    Content = "This is a test Dialogue that, when confirmed, will assign a quest to the player.",
    Next = [DialogueComponentWithoutContinuation],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
    Quest = QuestTests.SerializableQuestAllTasks
  };

  public static readonly DialogueComponent DialogueComponentWithContinuation = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test Dialogue With Continuation",
    Content = "This is a test Dialogue with continuation lines.",
    Next = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
  };


  public static void TestMakeCompleteDialogue()
  {
    FileController.CreateProjectFile(new ProjectFileInfo<DialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = DialogueComponentWithContinuation.Id.ToString() + ".json",
      FileData = DialogueComponentWithContinuation
    });

    FileController.CreateProjectFile(new ProjectFileInfo<DialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = DialogueComponentWithoutContinuation.Id.ToString() + ".json",
      FileData = DialogueComponentWithoutContinuation
    });


    FileController.CreateProjectFile(new ProjectFileInfo<QuestDialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = DialogueComponentWithQuest.Id.ToString() + ".json",
      FileData = DialogueComponentWithQuest
    });
  }
}