namespace Game;

public record class FindTaskComponent : IFindTaskComponent
{
  public TaskType TaskType { get; } = TaskType.FIND;

  public required IItemComponent TargetItem { get; set; }

  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }
}