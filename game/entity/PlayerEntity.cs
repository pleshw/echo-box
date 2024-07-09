using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class PlayerEntity : BaseEntity
{
  public PlayerEntity(string uniqueName) : base(uniqueName)
  {
    AddComponent(new DisplayNameComponent
    {
      DisplayName = "Alice"
    });

    AddComponent(new HasPositionComponent
    {
      Position = Vector2.Zero
    });

    AddComponent(new InventoryComponent
    {
      Owner = this,
      Items = [],
      MaxStackSize = 10
    });

    AddComponent(new EntityAttributesComponent
    {
      Agility = new() { Level = 1 },
      Dexterity = new() { Level = 1 },
      Intelligence = new() { Level = 1 },
      Luck = new() { Level = 1 },
      Strength = new() { Level = 1 },
      Vitality = new() { Level = 1 }
    });

    AddComponent(new AliveComponent
    {
      IsAlive = true
    });

    AddComponent(new RelationshipComponent
    {
      CompletedDialogs = [],
      Level = 0,
    });
  }

  [JsonConstructor]
  public PlayerEntity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {

  }

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}