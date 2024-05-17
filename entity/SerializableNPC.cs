using System.Numerics;
using System.Text.Json.Serialization;
using Dialogue;

namespace Entity;

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