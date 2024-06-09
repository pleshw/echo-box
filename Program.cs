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

    PlayerEntity? cc = FileController.GetFileDeserialized<PlayerEntity>("C:/Users/Usuário/Desktop/echo-box/data/entity/test/PlayerActor.json");
  }
}
