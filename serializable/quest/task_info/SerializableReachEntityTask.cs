using Game;

namespace Serializable;

public class SerializableReachEntityTask : IReachEntityTaskComponent
{
  public required GameEntity TargetEntity { get; set; }

  public required IDialogueComponent TargetDialogue { get; set; }

  public TaskType TaskType { get; } = TaskType.REACH_ENTITY;

  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }
}