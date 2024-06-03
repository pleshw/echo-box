using System.Numerics;

namespace Game;

public class PlayerEntity : GameEntity
{
  public PlayerEntity(Guid id) : base(id)
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
      MaxSize = 10
    });
  }

  public PlayerEntity(Guid id, List<IComponent> components) : base(id, components)
  {

  }

  public override List<Type> RequiredComponents => [typeof(IPositionComponent), typeof(IDisplayNameComponent), typeof(IInventoryComponent)];

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}