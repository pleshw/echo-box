using Game;

namespace Tests;


public static class EntityTests
{
    public static readonly PlayerEntity PlayerActor = new("PlayerActor");

    public static readonly NonPlayableEntity CompanionActor = new("CompanionActor", "Companion Test");

    public static readonly NonPlayableEntity TargetActor = new("TargetActor", "Target Test");

    public static readonly List<GameEntity> AllEntities = [PlayerActor, CompanionActor, TargetActor];

    public static void TestRemakeAllEntities()
    {
        AllEntities.ForEach(q => FileController.CreateProjectFile(
            new ProjectFileInfo<GameEntity>()
            {
                FolderPath = "entity/test/",
                FileName = q.UniqueName + ".json",
                FileData = q
            }
        ));
    }

    public static GameEntity GetEntityByUniqueName(string uniqueName)
    {
        return AllEntities.Where(q => q.UniqueName == uniqueName).FirstOrDefault() ?? throw new Exception($"Invalid deserialization. Entity {uniqueName} does not exist.");
    }
}