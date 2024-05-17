using System.Collections.Generic;
using System.Text.Json.Serialization;
using Entity;

namespace World;

public record class SerializableStage
{

  public required bool Visited;



  public required List<SerializableNPC> NPCs;
}