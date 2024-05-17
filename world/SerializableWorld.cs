using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace World;

public record class SerializableWorld
{
  [JsonInclude]
  public required string WorldSaveFolder;

  [JsonInclude]
  public required string WorldSaveFile;

  [JsonInclude]
  public required List<string> VisitedStages;
}