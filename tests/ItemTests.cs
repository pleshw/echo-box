using Serializable;
using Game;

namespace Tests;

public static class ItemTests
{
  public static readonly SerializableItem SerializableConsumableItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.CONSUMABLE,
    DisplayName = "Test Consumable",
    UniqueName = "TestConsumable",

    Description = "A Consumable for testing purposes",
    ImageFilePath = "test/image/filepath",
  };

  public static readonly SerializableItem SerializableArmorItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ARMOR,
    DisplayName = "Test Armor",
    UniqueName = "TestArmor",

    Description = "A Armor for testing purposes",
    ImageFilePath = "test/image/filepath",
  };

  public static readonly SerializableItem SerializableWeaponItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.WEAPON,
    DisplayName = "Test Weapon",
    UniqueName = "TestWeapon",

    Description = "A Weapon for testing purposes",
    ImageFilePath = "test/image/filepath",
  };

  public static readonly SerializableItem SerializableAccessoryItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ACCESSORY,
    DisplayName = "Test Accessory",
    UniqueName = "TestAccessory",

    Description = "A Accessory for testing purposes",
    ImageFilePath = "test/image/filepath",
  };

  public static readonly SerializableItem SerializableAllUsesItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ACCESSORY | ItemTypes.ARMOR | ItemTypes.WEAPON | ItemTypes.CONSUMABLE,
    DisplayName = "Test All Uses",
    UniqueName = "TestAllUses",

    Description = "A All Uses for testing purposes",
    ImageFilePath = "test/image/filepath",
  };

  public static readonly List<SerializableItem> AllTestItems = [SerializableConsumableItem, SerializableArmorItem, SerializableWeaponItem, SerializableAccessoryItem, SerializableAllUsesItem];

}