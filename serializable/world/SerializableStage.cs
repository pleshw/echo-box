using System.Collections.Generic;
using System.Text.Json.Serialization;
using Serializable;

namespace Serializable;

public record class SerializableStage
{

  public required bool Visited;



  public required List<SerializableNPC> NPCs;
}