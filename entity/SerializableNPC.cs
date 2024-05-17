using System.Collections.Generic;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Entity;

public class SerializableNPC : SerializableEntity
{
  [JsonInclude]
  public required string NodePath;

  [JsonInclude]
  public required bool SeenByPlayer;

  [JsonInclude]
  public required bool PlayerTalked;

  [JsonInclude]
  public required SerializableInteraction Interaction;

  [JsonInclude]
  public required Vector2 CurrentTile;
}