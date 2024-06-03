using Game;
using Serializable;

namespace Tests;

public static class DialogueTests
{
  public static readonly DialogueComponent DialogueComponentWithoutContinuation = new()
  {
    Id = Guid.NewGuid(),
    Title = "Test Dialogue",
    Content = "This is a test Dialogue without continuation.",
    Next = [],
    AlreadyCompleted = false,
    IsReadyToComplete = true,
  };

  public static void TestMakeCompleteDialogue()
  {
    SerializableDialogueNode defaultDialogueNode = new()
    {
      FolderPath = "dialogue/test/node/",
      FileName = "test_dialogue_default.json",
      Restrictions = null,
      Message = "Testing the default dialog of an NPC",
      SpeakersNodeNames = ["NPC1", "NPC2"],
      ListenersNodeNames = ["Player"],
      Options = [
        new SerializableDialogueOption
        {
          ButtonText = "Test completed"
        }
      ],
      QuestsEnabledOnComplete = []
    };

    SerializableDialogueNode firstInteractionDialogueNode = new()
    {
      FolderPath = "dialogue/test/node/",
      FileName = "test_first_interaction.json",
      Restrictions = null,
      Message = "Testing the default dialog of an NPC",
      SpeakersNodeNames = ["NPC1", "NPC2"],
      ListenersNodeNames = ["Player"],
      Options = [
        new()
        {
          ButtonText = "Test completed",
          DialogNodePath = defaultDialogueNode.FileName
        }
      ],
      QuestsEnabledOnComplete = []
    };


    SerializableDialogue dialogue = new()
    {
      FolderPath = "dialogue/test/",
      FileName = "test_dialogue.json",
      Title = "NPC Dialog",
      DefaultDialogueNodePath = defaultDialogueNode.FileName,
      FirstInteractionDialogueNodePath = firstInteractionDialogueNode.FileName,
    };

    FileController.CreateProjectFile(new List<ProjectFileInfo<SerializableDialogueNode>>
    {
        new(){
          FolderPath = defaultDialogueNode.FolderPath,
          FileName = defaultDialogueNode.FileName,
          FileData = defaultDialogueNode
        },
        new(){
          FolderPath = defaultDialogueNode.FolderPath,
          FileName = firstInteractionDialogueNode.FileName,
          FileData = firstInteractionDialogueNode
        }
    });

    FileController.CreateProjectFile(new ProjectFileInfo<SerializableDialogue>()
    {
      FolderPath = dialogue.FolderPath,
      FileName = dialogue.FileName,
      FileData = dialogue
    });
  }
}