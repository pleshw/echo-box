using Game;

namespace Serializable;

public record class SerializableSubQuest : ISerializableSubQuest
{
  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required QuestTask Task { get; set; }

  public bool IsCompleted
  {
    get
    {
      return true;
    }
  }
}
