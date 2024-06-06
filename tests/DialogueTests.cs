using Game;

namespace Tests;

public static class DialogueTests
{
  public static readonly DialogueComponent DialogueComponentWithoutContinuation = new()
  {
    Id = new Guid("26e2357a-ea5d-4cce-918d-62d8de0c964a"),
    Title = "Test Dialogue Without Continuation",
    Content = "This is a test Dialogue without continuation.",
    Options = [],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
    IsHidden = false,
  };

  public static readonly QuestDialogueComponent DialogueComponentWithQuest = new()
  {
    Id = new Guid("c00707b8-16d2-48af-a0a5-1d05c553a5f8"),
    Title = "Test Dialogue With Quest",
    Content = "This is a test Dialogue that, when confirmed, will assign a quest to the player.",
    Options = [DialogueComponentWithoutContinuation],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
    IsHidden = false,
    Quest = QuestTests.SerializableQuestAllTasks
  };

  public static readonly DialogueComponent DialogueComponentWithContinuation = new()
  {
    Id = new Guid("9c0f62b9-e88e-4367-b62c-f1321bb56f6a"),
    Title = "Test Dialogue With Continuation",
    Content = "This is a test Dialogue with continuation lines.",
    Options = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
    IsHidden = false,
  };

  public static readonly MenuDialogueComponent DialogueComponentWithMenu = new()
  {
    Id = new Guid("5ba44ffa-f02b-4bf3-a122-8a08ad9b8a8a"),
    Title = "Test Dialogue With Craft Menu and Continuation",
    Content = "This is a test Dialogue with a craft menu and some continuation lines.",
    Options = [DialogueComponentWithoutContinuation, DialogueComponentWithQuest],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
    IsHidden = false,
    MenuComponent = new MenuCraftComponent
    {
      DisplayName = "Craft your sword",
      ItemList = [ItemTests.SerializableCraftItemSlot],
      UniqueName = "CraftMenuDialogueComponentWithMenu"
    },
  };


  public static readonly List<IDialogueComponent> AllTestDialogues = [DialogueComponentWithMenu, DialogueComponentWithoutContinuation, DialogueComponentWithQuest, DialogueComponentWithContinuation];

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

    FileController.CreateProjectFile(new ProjectFileInfo<IDialogueComponent>()
    {
      FolderPath = "dialogue/test/",
      FileName = DialogueComponentWithMenu.Id.ToString() + ".json",
      FileData = DialogueComponentWithMenu
    });
  }

  public static void TestRemakeAllDialogues()
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