using Game;

namespace Serializable;

public record class SerializableItem : IItemComponent
{
  public required Guid Id;

  public ItemTypes ItemType { get; set; }

  public required string DisplayName { get; set; }

  public required string UniqueName { get; set; }

  public required string Description { get; set; }

  public required string ImageFilePath { get; set; }
}