namespace Game;

public enum TaskType
{
  COLLECT,
  HUNT,
  FIND,
  ESCORT,
  REACH_POSITION,
  REACH_ENTITY
}

[Flags]
public enum ItemTypes
{
  CONSUMABLE,
  ARMOR,
  WEAPON,
  ACCESSORY
}