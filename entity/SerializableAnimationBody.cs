
using System.Text.Json.Serialization;


namespace Entity;

public record class SerializableAnimationBody
{
  [JsonInclude]
  public Dictionary<string, string> ResourcePathByPart { get; } = [];

  public SerializableAnimationBody(Dictionary<string, string> resourcePathByPart)
  {
    ResourcePathByPart = resourcePathByPart;
  }
}