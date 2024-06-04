using System.Text.Json.Serialization;
using Game;

namespace Serializable;

public record class SerializableQuest : IQuestComponent
{
  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required List<ITaskComponent> Tasks { get; set; }
}

