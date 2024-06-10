using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Tests;

namespace Game;

public record class AssignedEscortTaskComponent : EscortTaskComponent, IAssignedEscortTaskComponent
{
  public bool IsReadyToComplete
  {
    get
    {
      bool isAssignedAlive = GetGameEntity().GetComponent<AliveComponent>().IsAlive;
      bool isCompanionInsideTheArea = true;
      return isAssignedAlive && isCompanionInsideTheArea;
    }
  }

  public required IUniqueNameComponent AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  [SetsRequiredMembers]
  public AssignedEscortTaskComponent(EscortTaskComponent t, IUniqueNameComponent assignedTo, DateTime startedAt)
  {
    Id = t.Id;
    Title = t.Title;
    Description = t.Description;
    AssignedTo = assignedTo;
    StartedAt = startedAt;

    Companion = t.Companion;
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }

  public static BaseEntity GetGameEntity()
  {
    return EntityTests.PlayerActor;
  }
}