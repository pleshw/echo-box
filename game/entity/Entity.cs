using System.Numerics;
using System.Text.Json.Serialization;

namespace Game;

public class Entity : BaseEntity
{
  [JsonConstructor]
  public Entity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {

  }

  public override IComponent Clone()
  {
    throw new NotImplementedException();
  }
}