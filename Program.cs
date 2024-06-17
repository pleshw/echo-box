using Game;
using Tests;


namespace EchoBox;

public static class Program
{
  private static void Main(string[] _)
  {
    DialogueTests.TestRemakeAllDialogues();
    QuestTests.TestRemakeAllQuests();
    StageTests.TestRemakeAllStages();
    StageBuilderTests.TestRemakeAllStages();
    EntityTests.TestRemakeAllEntities();

    StageComponent? stageComponent = FileController.GetFileDeserialized<StageComponent>("C:/Users/Usuário/Desktop/echo-box/data/stage/test/TestStage.json");
  }
}
