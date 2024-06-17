using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;


[JsonConverter(typeof(JsonBaseComponentConverter))]
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

  void LoadImage();
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

[JsonConverter(typeof(JsonShopItemConverter))]
public interface IShopItemComponent : IComponent, ICanHide, IHasPrice, IItemFrameComponent, IHasAmountComponent, IUniqueNameComponent
{

}

[JsonConverter(typeof(JsonCraftItemConverter))]
public interface ICraftItemComponent : IComponent, ICanHide, IHasPrice, IItemFrameComponent, IUniqueNameComponent
{
  List<IUniqueNameComponent> InputItems { get; set; }
}

public interface IHasAssignedEntity : IComponent
{
  IUniqueNameComponent AssignedTo { get; set; }
}

[JsonConverter(typeof(JsonQuestConverter))]
public interface IQuestComponent : IComponent, IIdComponent, ITitleComponent, IDescriptionComponent
{
  public List<ITaskComponent> Tasks { get; set; }
}

public interface IAssignedQuestComponent : IComponent, IIdComponent, ITitleComponent, IDescriptionComponent, IHasAssignedEntity
{
  public List<IAssignedTaskComponent> Tasks { get; set; }
}

public interface IHasStartComponent : IComponent
{
  DateTime StartedAt { get; set; }
}

[JsonConverter(typeof(JsonBaseAssignedTaskConverter))]
public interface IAssignedTaskComponent : IComponent, IHasAssignedEntity, IHasStartComponent, ITaskComponent, IIdComponent, ITitleComponent, IDescriptionComponent, ICompletableComponent
{

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

public interface IStageComponent : IComponent, IUniqueNameComponent
{
  List<IUniqueNameComponent> EntityList { get; set; }
  IGridMapComponent GridMap { get; set; }
}

[JsonConverter(typeof(JsonBaseGridMapConverter))]
public interface IGridMapComponent : IComponent, ICloneable, ICopyable
{
  List<IGridCellComponent> GridCells { get; set; }

  int Width { get; set; }

  int Height { get; set; }
}

public interface ICopyable : IComponent
{
  void Copy(ICopyable copyable);
}


[JsonConverter(typeof(JsonBaseGridCellConverter))]
public interface IGridCellComponent : IComponent, IPositionComponent, ISizeComponent, IIndexComponent, ICloneable, ICopyable
{
  GridCellStatus Status { get; set; }
}

public interface IGridDisplayCellComponent : IComponent, IGridCellComponent
{
  IGridCellImageComponent GridCellImage { get; set; }
}

public interface IGridCellImageComponent : IComponent
{
  IDisplayImageComponent StageSprite { get; set; }
  IDisplayImageComponent MinimapSprite { get; set; }
}

public interface IEscortTaskComponent : IComponent, ITaskComponent, ITargetAreaComponent
{
  IUniqueNameComponent Companion { get; set; }
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
  BaseEntity TargetEntity { get; set; }
}

public interface IAssignedHuntTaskComponent : IComponent, IHuntTaskComponent, IAssignedTaskComponent, IAmountKilledComponent
{
}

public interface IReachEntityTaskComponent : IComponent, ITaskComponent
{
  BaseEntity TargetEntity { get; set; }

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

public interface IPortraitDialogueComponent : IComponent, IDialogueComponent
{
  IDisplayImageComponent ListenerPortrait { get; set; }

  IDisplayImageComponent SpeakerPortrait { get; set; }
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

public interface IHasCapacityComponent : IComponent
{
  int Capacity { get; set; }
}


public interface IItemFrameComponent : IComponent
{
  IItemComponent Item { get; set; }
  IDisplayImageComponent FrameImage { get; set; }
}

public interface IItemSlotComponent : IComponent, IItemFrameComponent, IHasAmountComponent, IHasCapacityComponent
{
}

public interface IEquipSlotComponent : IComponent, IUniqueNameComponent, IDescriptionComponent, IDisplayNameComponent, IItemSlotComponent
{
}

[JsonConverter(typeof(JsonBaseInventoryConverter))]
public interface IInventoryComponent : IComponent, IHasCapacityComponent
{
  IUniqueNameComponent Owner { get; set; }

  List<IItemSlotComponent> Items { get; set; }
}

// Defines properties for entities that have a level
public interface ILevelComponent : IComponent
{
  int Level { get; set; }
}

public interface IIndexComponent : IComponent
{
  int Index { get; set; }
}


// Defines properties for entities with a position
public interface IPositionComponent : IComponent
{
  Vector2 Position { get; set; }
}

public interface ISizeComponent : IComponent
{
  Vector2 Size { get; set; }
}

public interface ITargetPositionComponent : IComponent
{
  Vector2 TargetPosition { get; set; }
}

public interface ITargetAreaComponent : IComponent, ISizeComponent, ITargetPositionComponent
{
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
[JsonConverter(typeof(JsonBaseUniqueNameConverter))]
public interface IUniqueNameComponent : IComponent
{
  public string UniqueName { get; }
}

public interface IIdComponent : IComponent
{
  public Guid Id { get; }
}
