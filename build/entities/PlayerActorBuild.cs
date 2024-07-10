using System.Numerics;
using Game;

namespace Build;

public class PlayerActorBuild : EntityActorBuild<PlayerEntity>
{
    private PlayerEntity? _playerActor;

    public override PlayerEntity Actor
    {
        get
        {
            _playerActor ??= new("PlayerActor");
            return _playerActor!;
        }
    }
}