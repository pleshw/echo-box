using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class PlayerEntity : BaseEntity
{
  public PlayerEntity(string uniqueName) : base(uniqueName)
  {
    AddComponent<IDisplayNameComponent>(new DisplayNameComponent
    {
      DisplayName = "Alice"
    });

    AddComponent<IPositionComponent>(new PositionComponent
    {
      Position = Vector2.Zero
    });

    AddComponent<IInventoryComponent>(new InventoryComponent
    {
      Owner = this,
      Items = [],
      Capacity = 10
    });

    AddComponent<IEntityAttributesComponent>(new EntityAttributesComponent
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

  [JsonConstructor]
  public PlayerEntity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {

  }

  [JsonIgnore]
  public override List<Type> RequiredComponents => [
    typeof(PositionComponent),
    typeof(DisplayNameComponent),
    typeof(AliveComponent),
    typeof(EntityAttributesComponent),
    typeof(InventoryComponent)
  ];

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}