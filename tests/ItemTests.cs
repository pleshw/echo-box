using Game;

namespace Tests;

public static class ItemTests
{
  public static readonly ItemComponent SerializableConsumableItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.CONSUMABLE,
    DisplayName = "Test Consumable",
    UniqueName = "TestConsumable",
    RequiredLevel = 0,

    Description = "A Consumable for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableArmorItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ARMOR,
    DisplayName = "Test Armor",
    UniqueName = "TestArmor",
    RequiredLevel = 0,
    Description = "A Armor for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableWeaponItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.WEAPON,
    DisplayName = "Test Weapon",
    UniqueName = "TestWeapon",
    RequiredLevel = 0,
    Description = "A Weapon for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableAccessoryItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ACCESSORY,
    DisplayName = "Test Accessory",
    UniqueName = "TestAccessory",
    RequiredLevel = 0,
    Description = "A Accessory for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableCraftedItemComponentAccessory = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ACCESSORY,
    DisplayName = "Test Accessory Input",
    UniqueName = "TestAccessoryInput",
    RequiredLevel = 0,
    Description = "A AccessoryInput for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableCraftedItemComponentArmor = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ARMOR,
    DisplayName = "Test Armor Input",
    UniqueName = "TestArmorInput",
    RequiredLevel = 0,
    Description = "A ArmorInput for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableCraftedItemComponentConsumable = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.CONSUMABLE,
    DisplayName = "Test Consumable Input",
    UniqueName = "TestConsumableInput",
    RequiredLevel = 0,
    Description = "A ConsumableInput for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableCraftedAccessoryItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ACCESSORY,
    DisplayName = "Test Crafted Accessory",
    UniqueName = "TestCraftedAccessory",
    RequiredLevel = 33,
    Description = "A Accessory for crafting purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly ItemComponent SerializableAllUsesItem = new()
  {
    Id = Guid.NewGuid(),
    ItemType = ItemTypes.ACCESSORY | ItemTypes.ARMOR | ItemTypes.WEAPON | ItemTypes.CONSUMABLE,
    DisplayName = "Test All Uses",
    UniqueName = "TestAllUses",
    RequiredLevel = 0,
    Description = "A All Uses for testing purposes",
    DisplayImage = "test/image/filepath",
  };

  public static readonly CraftItemComponent SerializableCraftItemSlot = new()
  {
    InputItems = [SerializableCraftedItemComponentAccessory, SerializableCraftedItemComponentArmor, SerializableCraftedItemComponentConsumable],
    IsHidden = false,
    Price = 0.0f,
    UniqueName = SerializableCraftedAccessoryItem.UniqueName + "Craft",
    Item = SerializableCraftedAccessoryItem,
    FrameImage = SerializableCraftedAccessoryItem,
  };

  public static readonly ShopItemComponent SerializableShopItemSlot1 = new()
  {
    UniqueName = SerializableCraftedAccessoryItem.UniqueName + "ShopItem",
    IsHidden = false,
    Price = 150.0f,
    Item = SerializableCraftedAccessoryItem,
    FrameImage = SerializableCraftedAccessoryItem,
    Amount = 10,
  };

  public static readonly ShopItemComponent SerializableShopItemSlot2 = new()
  {
    UniqueName = SerializableCraftedAccessoryItem.UniqueName + "ShopItem",
    IsHidden = false,
    Price = 130.0f,
    Item = SerializableCraftedAccessoryItem,
    FrameImage = SerializableCraftedAccessoryItem,
    Amount = 10,
  };

  public static readonly ShopItemComponent SerializableShopItemSlot3 = new()
  {
    UniqueName = SerializableCraftedAccessoryItem.UniqueName + "ShopItem",
    IsHidden = false,
    Price = 100.0f,
    Item = SerializableCraftedAccessoryItem,
    FrameImage = SerializableCraftedAccessoryItem,
    Amount = 10,
  };

  public static readonly List<ItemComponent> AllTestItems = [SerializableConsumableItem, SerializableArmorItem, SerializableWeaponItem, SerializableAccessoryItem, SerializableAllUsesItem];

  public static readonly List<IItemFrameComponent> AllTestItemFrames = [SerializableCraftItemSlot, SerializableShopItemSlot1, SerializableShopItemSlot2, SerializableShopItemSlot3];

  public static ICraftItemComponent GetCraftItemByUniqueName(string uniqueName)
  {
    return AllTestItemFrames.OfType<ICraftItemComponent>().Where(d => d.UniqueName == uniqueName).FirstOrDefault() ?? throw new Exception($"Item not found. Unique Name: {uniqueName}");
  }

  public static IShopItemComponent GetShopItemByUniqueName(string uniqueName)
  {
    return AllTestItemFrames.OfType<IShopItemComponent>().Where(d => d.UniqueName == uniqueName).FirstOrDefault() ?? throw new Exception($"Item not found. Unique Name: {uniqueName}");
  }
}