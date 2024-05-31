namespace Serializable;

public class SerializableEntity
{
  public required string DisplayName { get; set; }

  public required int Level { get; set; }

  public required SerializableAnimationBody Body { get; set; }

  public required SerializableEntityAttributes Attributes { get; set; }
}