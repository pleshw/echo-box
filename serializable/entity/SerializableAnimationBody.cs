namespace Serializable;

public record class SerializableAnimationBody
{
  public Dictionary<string, string> ResourcePathByPart { get; }

  public SerializableAnimationBody(Dictionary<string, string> resourcePathByPart)
  {
    ResourcePathByPart = resourcePathByPart;
  }

  public static explicit operator SerializableAnimationBody(Dictionary<string, string> v)
  {
    return new SerializableAnimationBody(v);
  }
}