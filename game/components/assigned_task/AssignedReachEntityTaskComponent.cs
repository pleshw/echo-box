namespace Game;

public record class AssignedReachEntityTaskComponent : IAssignedReachEntityTaskComponent
{
  public required GameEntity TargetEntity { get; set; }

  public required IDialogueComponent TargetDialogue { get; set; }

  public TaskType TaskType { get; } = TaskType.REACH_ENTITY;

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required GameEntity AssignedTo { get; set; }

  public required DateTime StartedAt { get; set; }

  public bool IsReadyToComplete
  {
    get
    {
      bool isAssignedAlive = AssignedTo.GetComponent<IAliveComponent>().IsAlive;
      IRelationshipComponent relationWithTarget = TargetEntity.GetComponent<IRelationshipComponent>();

      bool completedTargetDialogue = relationWithTarget.CompletedDialogs.Any(c => c.Id == TargetDialogue.Id);

      return isAssignedAlive && completedTargetDialogue;
    }
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}