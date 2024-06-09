using Game;
using Tests;


namespace EchoBox;

public static class Program
{
  private static void Main(string[] _)
  {
    DialogueTests.TestRemakeAllDialogues();
    QuestTests.TestRemakeAllQuests();
    EntityTests.TestRemakeAllEntities();
  }
}
