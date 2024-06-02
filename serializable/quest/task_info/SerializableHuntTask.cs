using Game;

namespace Serializable;

public class SerializableHuntTask : IHuntTaskComponent
{
  public TaskType TaskType { get; } = TaskType.HUNT;

  public required GameEntity TargetEntity { get; set; }


  public required string Id { get; set; }

  public required string Title { get; set; }
  public required string Description { get; set; }
  public required int Amount { get; set; }
}