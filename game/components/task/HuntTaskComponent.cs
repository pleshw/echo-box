namespace Game;

public record class HuntTaskComponent : IHuntTaskComponent
{
  public TaskType TaskType { get; } = TaskType.HUNT;

  public required GameEntity TargetEntity { get; set; }


  public required Guid Id { get; set; }

  public required string Title { get; set; }
  public required string Description { get; set; }
  public required int Amount { get; set; }
}