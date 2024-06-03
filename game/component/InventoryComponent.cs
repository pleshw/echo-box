using System.Numerics;

namespace Game;

public class InventoryComponent : IInventoryComponent
{
  public required IIdComponent Owner { get; set; }
  public List<IItemSlotComponent> Items { get; set; } = [];
  public required int MaxSize { get; set; }
}