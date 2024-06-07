namespace Game;

public record class ReachEntityTaskComponent : TaskComponent, IReachEntityTaskComponent
{
  public required GameEntity TargetEntity { get; set; }

  public required IDialogueComponent TargetDialogue { get; set; }

  public override TaskType TaskType { get; } = TaskType.REACH_ENTITY;
}