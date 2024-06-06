using Game;
using Tests;


namespace EchoBox;

public static class Program
{
  private static void Main(string[] _)
  {
    DialogueTests.TestRemakeAllDialogues();

    var test = FileController.GetFileDeserialized<MenuDialogueComponent>("C:/Users/Usuário/Desktop/echo-box/data/dialogue/test/5ba44ffa-f02b-4bf3-a122-8a08ad9b8a8a.json");

    System.Console.WriteLine(test);

    QuestTests.TestRemakeAllQuests();
  }
}
