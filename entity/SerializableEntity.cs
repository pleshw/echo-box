using System.Text.Json.Serialization;

namespace Entity;

public class SerializableEntity
{
  [JsonInclude]
  public required string DisplayName { get; set; } = "";

  [JsonInclude]
  public required int Level { get; set; } = 1;

  [JsonInclude]
  public required SerializableAnimationBody Body { get; set; }

  [JsonInclude]
  public required EntityAttributes Attributes { get; set; } = new();
}