using Game;

namespace Tests;


public static class EntityTests
{
    public static readonly PlayerEntity PlayerActor = new("PlayerActor");

    public static readonly NonPlayableEntity CompanionActor = new("CompanionActor");

    public static readonly NonPlayableEntity TargetActor = new("TargetActor");

    public static void TestMakeCompleteNPC()
    {
        // FileController.CreateProjectFile("npc_test.json", npc);
    }
}