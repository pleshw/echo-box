using System.Text.Json.Serialization;
using Quest;

namespace Dialogue;

public record class SerializableDialogue
{

  public required string NodePath;


  public required string Title;


  public required string DefaultDialogueNodePath;


  public required string FirstInteractionDialogueNodePath;
}