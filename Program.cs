using System.Diagnostics.CodeAnalysis;
using Main;


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
  }
}
