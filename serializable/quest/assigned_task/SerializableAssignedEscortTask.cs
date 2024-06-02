using System.Numerics;
using Game;

namespace Serializable;

public class SerializableAssignedEscortTask : IAssignedEscortTaskComponent
{
  public TaskType TaskType { get; } = TaskType.ESCORT;

  public required GameEntity Companion { get; set; }

  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required Vector2 TargetPosition { get; set; }

  public required Vector2 Size { get; set; }

  public required GameEntity AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  public bool IsReadyToComplete
  {
    get
    {
      bool isAssignedAlive = AssignedTo.GetComponent<IAliveComponent>().IsAlive;
      bool isCompanionInsideTheArea = true;
      return isAssignedAlive && isCompanionInsideTheArea;
    }
  }


  public void Complete()
  {
    throw new NotImplementedException();
  }
}