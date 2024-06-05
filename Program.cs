using Game;
using Tests;


namespace EchoBox;

public static class Program
{
  private static void Main(string[] _)
  {
    DialogueTests.TestRemakeAllDialogues();

    var test = FileController.GetFileDeserialized<QuestDialogueComponent>("C:/Users/Usuário/Desktop/echo-box/data/dialogue/test/c00707b8-16d2-48af-a0a5-1d05c553a5f8.json");

    System.Console.WriteLine(test);

    QuestTests.TestRemakeAllQuests();
  }
}
