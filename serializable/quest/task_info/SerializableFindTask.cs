using Game;

namespace Serializable;

public class SerializableFindTask : IFindTaskComponent
{
  public TaskType TaskType { get; } = TaskType.FIND;

  public required IItemComponent TargetItem { get; set; }

  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }
}