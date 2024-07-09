using System.Numerics;
using Game;

namespace Build;

public class PlayerActorBuild : ICanSaveFileComponent, ICanLoadFileComponent<PlayerEntity>
{
    private static PlayerEntity? _playerActor;
    private static PlayerEntity PlayerActor
    {
        get
        {
            _playerActor ??= new("PlayerActor");
            return _playerActor!;
        }
    }

    public void SaveFile()
    {
        FileController.CreateProjectFile(
                    $"entity/{PlayerActor.UniqueName}/",
                    "actor.json",
                    PlayerActor
            );
    }

    public PlayerEntity LoadFile()
    {
        return FileController.GetFileDeserialized<PlayerEntity>($"C:/Users/Usuário/Desktop/echo-box/data/entity/{PlayerActor.UniqueName}/actor.json")
                ?? throw new FileNotFoundException("Invalid file.");
    }
}