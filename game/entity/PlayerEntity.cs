using Game;

namespace Game;

public class PlayerEntity : GameEntity
{
  public PlayerEntity(string id) : base(id)
  {
  }

  public PlayerEntity(string id, List<IComponent> components) : base(id, components)
  {
  }

  public PlayerEntity(string id, GameEntity entityToCopy) : base(id, entityToCopy)
  {
  }

  public override List<Type> RequiredComponents => [typeof(IPositionComponent), typeof(IDisplayNameComponent), typeof(IInventoryComponent)];

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}