using Game;

namespace Tests;

public static class DialogueTests
{
  public static readonly DialogueComponent DialogueComponentWithoutContinuation = new()
  {
    Id = new Guid("26e2357a-ea5d-4cce-918d-62d8de0c964a"),
    Title = "Test Dialogue Without Continuation",
    Content = "This is a test Dialogue without continuation.",
    Next = [],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
  };

  public static readonly QuestDialogueComponent DialogueComponentWithQuest = new()
  {
    Id = new Guid("c00707b8-16d2-48af-a0a5-1d05c553a5f8"),
    Title = "Test Dialogue With Quest",
    Content = "This is a test Dialogue that, when confirmed, will assign a quest to the player.",
    Next = [DialogueComponentWithoutContinuation],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
    Quest = QuestTests.SerializableQuestAllTasks
  };

  public static readonly DialogueComponent DialogueComponentWithContinuation = new()
  {
    Id = new Guid("9c0f62b9-e88e-4367-b62c-f1321bb56f6a"),
    Title = "Test Dialogue With Continuation",
    Content = "This is a test Dialogue with continuation lines.",
    Next = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
  };


  public static readonly List<IDialogueComponent> AllTestDialogues = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest, DialogueComponentWithContinuation];

  public static void TestMakeCompleteDialogue()
  {
    FileController.CreateProjectFile(new ProjectFileInfo<IDialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = DialogueComponentWithContinuation.Id.ToString() + ".json",
      FileData = DialogueComponentWithContinuation
    });

    FileController.CreateProjectFile(new ProjectFileInfo<IDialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = DialogueComponentWithoutContinuation.Id.ToString() + ".json",
      FileData = DialogueComponentWithoutContinuation
    });

    FileController.CreateProjectFile(new ProjectFileInfo<IDialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = DialogueComponentWithQuest.Id.ToString() + ".json",
      FileData = DialogueComponentWithQuest
    });
  }

  public static void TestMakeAllDialogues()
  {
    AllTestDialogues.ForEach(d => FileController.CreateProjectFile(new ProjectFileInfo<IDialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = d.Id.ToString() + ".json",
      FileData = d
    }));
  }

  public static IDialogueComponent GetDialogueById(Guid dialogueId)
  {
    return AllTestDialogues.Where(q => q.Id == dialogueId).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Dialogue {dialogueId} does not exist.");
  }
}