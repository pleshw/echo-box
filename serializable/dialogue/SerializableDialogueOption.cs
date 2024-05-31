namespace Serializable;

public record class SerializableDialogueOption
{

  public required string ButtonText;


  /// <summary>
  /// if null or empty will end the dialogue
  /// </summary>
  public string? DialogNodePath;
}
