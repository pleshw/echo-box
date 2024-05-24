using System.Diagnostics.CodeAnalysis;
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
  }
}
