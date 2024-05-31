namespace Serializable;

public record class SerializableInteraction
{

  public required List<string> CompletedDialoguePaths;


  public required List<string> NotSeenDialoguePaths;
}