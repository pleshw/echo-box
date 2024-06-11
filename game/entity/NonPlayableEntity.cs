using System.Numerics;
using System.Text.Json.Serialization;

namespace Game;

public class NonPlayableEntity : BaseEntity
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
      Level = 0,
    });
  }

  [JsonConstructor]
  public NonPlayableEntity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {

  }

  [JsonIgnore]
  public override List<Type> RequiredComponents => [
    typeof(PositionComponent),
    typeof(RelationshipComponent),
    typeof(DisplayNameComponent),
    typeof(InventoryComponent)
  ];

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}