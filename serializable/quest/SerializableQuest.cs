using System.Text.Json.Serialization;

namespace Serializable;

public record class SerializableQuest : ISerializableQuest
{
  public required string Id { get; set; }


  public required string Title { get; set; }


  public required string Description { get; set; }


  public required List<SerializableSubQuest> SubQuests { get; set; }
}

