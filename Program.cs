using Build;
using Game;


namespace EchoBox;

public static class Program
{
  private static void Main(string[] _)
  {

    var playerBuilder = new PlayerActorBuild();
    var cc = playerBuilder.LoadFile();


    var aliceOutsideHouseBuilder = new AliceHouseOutsideBuild();
    var dd = aliceOutsideHouseBuilder.LoadFile();

    // DialogueTests.TestRemakeAllDialogues();
    // QuestTests.TestRemakeAllQuests();
    // StageTests.TestRemakeAllStages();
    // StageBuilderTests.TestRemakeAllStages();
    // EntityTests.TestRemakeAllEntities();

    // StageComponent? stageComponent = FileController.GetFileDeserialized<StageBuilderComponent>("C:/Users/Usuário/Desktop/echo-box/data/stage/test/TestStageBuilder.json");

    // EntityTests.TestRemakeBehaviourEntity();
    // BehaviourEntity? behaveNPCComponent = FileController.GetFileDeserialized<BehaviourEntity>("C:/Users/Usuário/Desktop/echo-box/data/entity/test/BehaviourNPCActor.json");
  }
}
