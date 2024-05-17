using System.Text.Json.Serialization;
using Quest;

namespace Dialogue;

public record class SerializableDialogueOption
{
  [JsonInclude]
  public required string ButtonText;

  [JsonInclude]
  public required string DialogNode;
}
