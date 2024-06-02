using Game;

namespace Serializable;

public record class SerializableQuest : IQuestComponent
{
  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required List<ITaskComponent> Tasks { get; set; }
}

