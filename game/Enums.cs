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

public enum MenuType
{
  SHOP,
  CRAFT,
  PICK_ITEM
}

[Flags]
public enum ItemTypes
{
  NONE = 0,
  CONSUMABLE = 1 << 1,
  ARMOR = 1 << 2,
  WEAPON = 1 << 3,
  ACCESSORY = 1 << 4
}