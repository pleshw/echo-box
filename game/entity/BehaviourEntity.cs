using System.Numerics;

namespace Game;

public class BehaviourEntity : NonPlayableEntity, IEntityBehaviourComponent
{
  public required BehaviourType BehaviourType { get; set; }

  public required IUniqueNameComponent CurrentStage { get; set; }

  public required Vector2 Position { get; set; }

  public required Vector2 TargetPosition { get; set; }

  public BehaviourEntity(string uniqueName, List<IComponent> components) : base(uniqueName, components)
  {
  }

  public virtual void RunEntityBehaviour()
  {

  }
}