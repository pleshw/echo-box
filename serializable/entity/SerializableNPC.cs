using System.Numerics;

namespace Serializable;

public class SerializableNPC : SerializableEntity
{
  public required string NodePath;

  // Data that has to be cached by player save
  // 
  // public required bool SeenByPlayer;

  // 
  // public required bool PlayerTalked;

  public required SerializableDialogue Dialogue;

  public required Vector2 CurrentTile;
}