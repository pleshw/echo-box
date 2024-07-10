using System.Numerics;
using Game;

namespace Build;

public class JulliaActorBuild : EntityActorBuild<BehaviourEntity>
{
  private static BehaviourEntity? _julliaActor;

  private static readonly IEntityRoutineComponent DefaultRoutine = new EntityRoutineComponent
  {
    EntityBehaviourByGameTime = new()
    {
      {0, new EntityBehaviourComponent{
        BehaviourType = BehaviourType.IDLE,
        CurrentStage = new AliceHouseBuild().LoadFile(),
        Position = new(),
        TargetPosition = new()
      }}
    }
  };

  public override BehaviourEntity Actor
  {
    get
    {
      _julliaActor ??= new("JulliaActor", new EntityScheduleComponent
      {

      }, [

      ]);
      return _julliaActor!;
    }
  }

}