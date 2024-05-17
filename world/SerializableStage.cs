using System.Collections.Generic;
using System.Text.Json.Serialization;
using Entity;

namespace World;

public record class SerializableStage
{
  [JsonInclude]
  public required bool Visited;


  [JsonInclude]
  public required List<SerializableNPC> NPCs;
}