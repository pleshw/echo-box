namespace Serializable;

public record class SerializableWorld
{

  public required string WorldSaveFolder;


  public required string WorldSaveFile;


  public required List<string> VisitedStages;
}