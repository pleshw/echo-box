namespace Game;

public record class CollectTaskComponent : ICollectTaskComponent
{
  public TaskType TaskType { get; } = TaskType.COLLECT;

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required IItemComponent TargetItem { get; set; }

  public required int Amount { get; set; }
}