using System.Text.Json.Serialization;
using Quest;

namespace Dialogue;

public record class SerializableDialogueOption
{

  public required string ButtonText;


  public required string DialogNode;
}
