using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;


[JsonConverter(typeof(JsonComponentConverter))]
public interface IComponent
{
}

public interface IEntityAttributesComponent : IComponent
{
  Agility Agility { get; set; }
  Dexterity Dexterity { get; set; }
  Intelligence Intelligence { get; set; }
  Luck Luck { get; set; }
  Strength Strength { get; set; }
  Vitality Vitality { get; set; }
}

// Defines properties for displaying the name
public interface IDisplayNameComponent : IComponent
{
  string DisplayName { get; set; }
}

public interface ICanHide : IComponent
{
  bool IsHidden { get; set; }

  void Show();

  void Hide();

  bool HideCondition();
}

[JsonConverter(typeof(JsonDisplayImageConverter))]
public interface IDisplayImageComponent : IComponent
{
  string DisplayImage { get; set; }
}

public interface ITitleComponent : IComponent
{
  string Title { get; set; }
}

public interface IDescriptionComponent : IComponent
{
  string Description { get; set; }
}

public interface ITextContentComponent : IComponent
{
  string Content { get; set; }
}

public interface IEquipComponent : IComponent, IItemComponent
{
  public void Equip(IEquipSlotComponent slot);
}

public interface IConsumableComponent : IComponent, IHasAmountComponent
{
  public void Consume();
}

public interface IAmountCollectedComponent : IComponent
{
  int AmountCollected { get; set; }
}

public interface IAmountKilledComponent : IComponent
{
  int AmountKilled { get; set; }
}

[JsonConverter(typeof(JsonItemConverter))]
public interface IItemComponent : IComponent, IDisplayNameComponent, IUniqueNameComponent, IDescriptionComponent, IDisplayImageComponent, IHasRequiredLevel
{
  ItemTypes ItemType { get; set; }
}

public interface IHasPrice : IComponent
{
  float Price { get; set; }
}

public interface IHasRequiredLevel : IComponent
{
  int RequiredLevel { get; set; }
}

public interface IShopItemComponent : IComponent, ICanHide, IHasPrice, IItemFrameComponent, IHasAmountComponent
{

}


[JsonConverter(typeof(JsonCraftItemConverter))]
public interface ICraftItemComponent : IComponent, ICanHide, IHasPrice, IItemFrameComponent
{
  List<IItemComponent> InputItemList { get; set; }
}

public interface IQuestComponent : IComponent, IIdComponent, ITitleComponent, IDescriptionComponent
{
  public List<ITaskComponent> Tasks { get; set; }
}

public interface IHasStartComponent : IComponent
{
  DateTime StartedAt { get; set; }
}

public interface IAssignedTaskComponent : IComponent, IHasStartComponent, ITaskComponent, IIdComponent, ITitleComponent, IDescriptionComponent, ICompletableComponent
{
  GameEntity AssignedTo { get; set; }
}

[JsonConverter(typeof(JsonTaskConverter))]
public interface ITaskComponent : IComponent, IIdComponent, ITitleComponent, IDescriptionComponent
{
  TaskType TaskType { get; }
}

public interface ICollectTaskComponent : IComponent, ITaskComponent, IHasAmountComponent
{
  IItemComponent TargetItem { get; set; }
}

public interface IAssignedCollectTaskComponent : IComponent, ICollectTaskComponent, IAssignedTaskComponent, IAmountCollectedComponent
{
}

public interface IEscortTaskComponent : IComponent, ITaskComponent, ITargetAreaComponent
{
  GameEntity Companion { get; set; }
}

public interface IAssignedEscortTaskComponent : IComponent, IEscortTaskComponent, IAssignedTaskComponent
{
}

public interface IFindTaskComponent : IComponent, ITaskComponent
{
  IItemComponent TargetItem { get; set; }
}

public interface IAssignedFindTaskComponent : IComponent, IFindTaskComponent, IAssignedTaskComponent, IAmountCollectedComponent
{
}


public interface IHuntTaskComponent : IComponent, ITaskComponent, IHasAmountComponent
{
  GameEntity TargetEntity { get; set; }
}

public interface IAssignedHuntTaskComponent : IComponent, IHuntTaskComponent, IAssignedTaskComponent, IAmountKilledComponent
{
}

public interface IReachEntityTaskComponent : IComponent, ITaskComponent
{
  GameEntity TargetEntity { get; set; }

  IDialogueComponent TargetDialogue { get; set; }
}

public interface IAssignedReachEntityTaskComponent : IComponent, IReachEntityTaskComponent, IAssignedTaskComponent
{

}

public interface IReachPositionTaskComponent : IComponent, ITaskComponent, ITargetAreaComponent
{

}

public interface IAssignedReachPositionTaskComponent : IComponent, IReachPositionTaskComponent, IAssignedTaskComponent
{

}

public interface ICanOpen : IComponent
{
  void Open();
}

public interface ICanClose : IComponent
{
  void Close();
}

[JsonConverter(typeof(JsonMenuConverter))]
public interface IMenuComponent : IComponent, IDisplayNameComponent, IUniqueNameComponent, ICanOpen, ICanClose
{
  MenuType MenuType { get; set; }
}

public interface IMenuShopComponent : IComponent, IMenuComponent
{
  List<IShopItemComponent> ItemList { get; set; }
}

public interface IMenuCraftComponent : IComponent, IMenuComponent
{
  List<ICraftItemComponent> ItemList { get; set; }
}

public interface IMenuPickItemComponent : IComponent, IMenuComponent
{
  List<IItemSlotComponent> ItemList { get; set; }
}

[JsonConverter(typeof(JsonDialogueBriefingConverter))]
public interface IDialogueBriefingComponent : IComponent, ICanHide, IIdComponent, ITitleComponent
{
}

public interface IDialogueComponent : IComponent, IDialogueBriefingComponent, ITextContentComponent, IMultipleCompletableComponent, ICancelComponent
{
  List<IDialogueBriefingComponent> Options { get; set; }
}

public interface IMenuDialogueComponent : IComponent, IDialogueComponent
{
  IMenuComponent MenuComponent { get; set; }
}

public interface IQuestDialogueComponent : IComponent, IDialogueComponent
{
  IIdComponent Quest { get; set; }
}

public interface IRelationshipComponent : IComponent, ILevelComponent
{
  List<IDialogueComponent> CompletedDialogs { get; set; }
  List<IDialogueComponent> NotSeenDialogs { get; set; }
}

public interface ICompletableComponent : IComponent
{
  bool IsReadyToComplete { get; }

  void Complete();
}

public interface IMultipleCompletableComponent : IComponent, ICompletableComponent
{
  bool AlreadyCompleted { get; }
}

public interface ICancelComponent : IComponent
{
  public void Cancel();
}

public interface IHasAmountComponent : IComponent
{
  int Amount { get; set; }
}

public interface IMaxSizeComponent : IComponent
{
  int MaxSize { get; set; }
}


public interface IItemFrameComponent : IComponent, IHasRequiredLevel
{
  IItemComponent Item { get; set; }
  IDisplayImageComponent FrameImage { get; set; }
}

public interface IItemSlotComponent : IComponent, IItemFrameComponent, IHasAmountComponent, IMaxSizeComponent, IHasRequiredLevel
{
}

public interface IEquipSlotComponent : IComponent, IUniqueNameComponent, IDescriptionComponent, IDisplayNameComponent, IItemSlotComponent
{
}

public interface IInventoryComponent : IComponent, IMaxSizeComponent
{
  IUniqueNameComponent Owner { get; set; }

  List<IItemSlotComponent> Items { get; set; }
}

// Defines properties for entities that have a level
public interface ILevelComponent : IComponent
{
  int Level { get; set; }
}

// Defines properties for entities with a position
public interface IPositionComponent : IComponent
{
  Vector2 Position { get; set; }
}

public interface ITargetPositionComponent : IComponent
{
  Vector2 TargetPosition { get; set; }
}

public interface ITargetAreaComponent : IComponent, ITargetPositionComponent
{
  Vector2 Size { get; set; }
}

public interface IIdentifiableTargetComponent : IComponent
{
  IUniqueNameComponent Target { get; set; }
}

// Defines properties for entities that can be alive or dead
public interface IAliveComponent : IComponent
{
  bool IsAlive { get; set; }
}

// Defines properties for entities that have a body
public interface IBodyComponent : IComponent
{
}

public interface IAttributeComponent : IHasAbbreviation, IUniqueNameComponent, ILevelComponent
{
}

public interface IHasAbbreviation : IComponent
{
  public string Abbreviation { get; set; }
}

// Defines properties for entities with attributes
public interface IAttributeListComponent : IComponent
{
  EntityAttributesComponent Attributes { get; set; }
}


/// A name that can be compared. If the element is used in an item, its unique name should be 'orange', so it can be compared to other items with the same name.
public interface IUniqueNameComponent : IComponent
{
  public string UniqueName { get; }
}

public interface IIdComponent : IComponent
{
  public Guid Id { get; }
}
