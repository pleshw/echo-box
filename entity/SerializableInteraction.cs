using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entity;

public record class SerializableInteraction
{
  [JsonInclude]
  public required List<string> NodePathCompletedDialogues;

  [JsonInclude]
  public required List<string> NodePathNotSeenDialogues;
}