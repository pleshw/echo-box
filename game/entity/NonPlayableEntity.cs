using System.Numerics;
using System.Text.Json.Serialization;

namespace Game;

public class NonPlayableEntity : GameEntity
{
  public NonPlayableEntity(string uniqueName) : base(uniqueName)
  {
    AddComponent(new DisplayNameComponent
    {
      DisplayName = "Alice"
    });

    AddComponent(new PositionComponent
    {
      Position = Vector2.Zero
    });

    AddComponent(new InventoryComponent
    {
      Owner = this,
      Items = [],
      MaxSize = 10
    });
  }

  public NonPlayableEntity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {

  }

  [JsonIgnore]
  public override List<Type> RequiredComponents => [typeof(IPositionComponent), typeof(IDisplayNameComponent), typeof(IInventoryComponent)];

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}