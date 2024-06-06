namespace Game;

public record class ReachEntityTaskComponent : IReachEntityTaskComponent
{
  public required GameEntity TargetEntity { get; set; }

  public required IDialogueComponent TargetDialogue { get; set; }

  public TaskType TaskType { get; } = TaskType.REACH_ENTITY;

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }
}