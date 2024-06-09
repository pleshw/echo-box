using System.Numerics;
using System.Text.Json.Serialization;

namespace Game;

public class NonPlayableEntity : GameEntity
{
  public NonPlayableEntity(string uniqueName, string displayName) : base(uniqueName)
  {
    AddComponent(new DisplayNameComponent
    {
      DisplayName = displayName
    });

    AddComponent(new PositionComponent
    {
      Position = Vector2.Zero
    });

    AddComponent(new InventoryComponent
    {
      Owner = this,
      Items = [],
      Capacity = 10
    });

    AddComponent(new AliveComponent
    {
      IsAlive = true
    });

    AddComponent(new RelationshipComponent
    {
      CompletedDialogs = [],
      NotSeenDialogs = [],
      Level = 0,
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