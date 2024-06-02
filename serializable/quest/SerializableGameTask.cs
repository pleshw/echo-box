using Game;

namespace Serializable;

public record class SerializableGameTask : ITaskComponent
{
  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required TaskType TaskType { get; set; }
}
