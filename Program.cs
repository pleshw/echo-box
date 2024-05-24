using System.Diagnostics.CodeAnalysis;
using Dialogue;
using Entity;
using Main;
using Quest;


namespace EchoBox;

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static class Program
{
  private static void Main(string[] _)
  {
    NPCManager.TestMakeCompleteNPC();
    DialogueManager.TestMakeCompleteDialogue();
    QuestManager.TestMakeCompleteQuest();

    SerializableQuest? deserializedQuest = FileController.GetFileDeserialized<SerializableQuest>("C:/Users/Usuário/Desktop/echo-box/data/quest/test/test_quest.json");

    SerializableDialogue? deserializedDialogue = FileController.GetFileDeserialized<SerializableDialogue>("C:/Users/Usuário/Desktop/echo-box/data/dialogue/test/test_dialogue.json");
    SerializableDialogueNode? deserializedDialogueNodeDefault = FileController.GetFileDeserialized<SerializableDialogueNode>("C:/Users/Usuário/Desktop/echo-box/data/dialogue/test/node/test_dialogue_default.json");
    SerializableDialogueNode? deserializedDialogueNodeFirstInteraction = FileController.GetFileDeserialized<SerializableDialogueNode>("C:/Users/Usuário/Desktop/echo-box/data/dialogue/test/node/test_first_interaction.json");

    SerializableNPC? deserializedNPC = FileController.GetFileDeserialized<SerializableNPC>("C:/Users/Usuário/Desktop/echo-box/data/npc_test.json");
  }
}
