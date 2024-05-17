using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace World;

public record class SerializableWorld
{

  public required string WorldSaveFolder;


  public required string WorldSaveFile;


  public required List<string> VisitedStages;
}