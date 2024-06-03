using System.Text.Json.Serialization;

namespace Game;

public class InventoryComponent : IInventoryComponent
{
  [JsonIgnore]
  public required IUniqueNameComponent Owner { get; set; }

  public required List<IItemSlotComponent> Items { get; set; }

  public required int MaxSize { get; set; }
}