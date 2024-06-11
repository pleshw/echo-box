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
  NONE,
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
  ACCESSORY = 1 << 4,
  MISC = 1 << 5,
  QUEST = 1 << 6
}

[Flags]
public enum GridCellStatus
{
  NONE = 0,
  FREE = 1 << 1,
  BLOCKED = 1 << 2,
  OCCUPIED = 1 << 3,
  VISITED = 1 << 4,
  HIDDEN = 1 << 5,
  HIGHLIGHTED = 1 << 6
}