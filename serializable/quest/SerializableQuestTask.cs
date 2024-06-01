namespace Serializable;

public record class SerializableQuestTask : ISerializableSubQuest
{
  public required string Id { get; set; }

  public required string Title { get; set; }

  public required string Description { get; set; }

  public required SerializableQuestTaskInfo TaskInfo { get; set; }
}
