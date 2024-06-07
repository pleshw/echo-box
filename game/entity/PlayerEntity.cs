using System.Numerics;
using System.Text.Json.Serialization;

namespace Game;

public class PlayerEntity : GameEntity
{
  public PlayerEntity(string uniqueName) : base(uniqueName)
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

    AddComponent(new EntityAttributesComponent
    {
      Agility = new() { Level = 3 },
      Dexterity = new() { Level = 3 },
      Intelligence = new() { Level = 3 },
      Luck = new() { Level = 3 },
      Strength = new() { Level = 3 },
      Vitality = new() { Level = 3 }
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

  public PlayerEntity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {

  }

  [JsonIgnore]
  public override List<Type> RequiredComponents => [
    typeof(IPositionComponent),
    typeof(IDisplayNameComponent),
    typeof(IAliveComponent),
    typeof(IEntityAttributesComponent),
    typeof(IInventoryComponent)
  ];

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}