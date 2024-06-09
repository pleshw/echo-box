using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

[JsonConverter(typeof(JsonInventoryConverter))]
public class InventoryComponent : IInventoryComponent
{
  public required IUniqueNameComponent Owner { get; set; }

  public required List<IItemSlotComponent> Items { get; set; }

  public required int Capacity { get; set; }
}