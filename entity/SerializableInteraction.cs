using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entity;

public record class SerializableInteraction
{

  public required List<string> CompletedDialoguePaths;


  public required List<string> NotSeenDialoguePaths;
}