using System.Numerics;
using Game;

namespace Build;

public class JulliaActorBuild : EntityActorBuild<BehaviourEntity>
{
  public static readonly StageComponent AliceHouseOutside = new AliceHouseOutsideBuild().LoadFile();

  private static BehaviourEntity? _julliaActor;

  private static readonly IEntityRoutineComponent DefaultRoutine = new EntityRoutineComponent
  {
    EntityBehaviourByGameTime = new()
    {
      { 0, new EntityBehaviourComponent
          {
            BehaviourType = BehaviourType.IDLE,
            CurrentStage = AliceHouseOutside,
            Position = new(),
            TargetPosition = new(20,20)
          }
      }
    }
  };

  public override BehaviourEntity Actor
  {
    get
    {
      _julliaActor ??= new("JulliaActor", new EntityScheduleComponent
      {
        DefaultRoutine = DefaultRoutine,

        EntityRoutineByGameDay = new()
        {
          {1, DefaultRoutine},
        },
      }, [

      ]);
      return _julliaActor!;
    }
  }

}