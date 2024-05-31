using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Serializable;

public record class SerializableInteraction
{

  public required List<string> CompletedDialoguePaths;


  public required List<string> NotSeenDialoguePaths;
}