namespace Game;

public abstract class GameEntity : IIdComponent
{
  public Guid Id { get; set; }

  public abstract List<Type> RequiredComponents { get; }

  private readonly Dictionary<Type, IComponent> _components = [];

  public GameEntity(Guid id)
  {
    Id = id;
  }

  public GameEntity(Guid id, List<IComponent> components)
  {
    Id = id;

    foreach (var component in components)
    {
      _components[component.GetType()] = component;
    }
  }

  public void AddComponent(IComponent component)
  {
    _components[component.GetType()] = component;
  }

  public bool HasRequiredComponents
  {
    get
    {
      foreach (var componentType in RequiredComponents)
      {
        if (!_components.ContainsKey(componentType))
        {
          return false;
        }
      }

      return true;
    }
  }

  public T GetComponent<T>() where T : IComponent
  {
    if (!_components.TryGetValue(typeof(T), out IComponent? component))
    {
      throw new Exception($"Component {typeof(T)} does not exist in this entity. Entity Id: {Id}");
    }

    return (T)component;
  }

  public void RemoveComponent<T>() where T : IComponent
  {
    _components.Remove(typeof(T));
  }

  public abstract IComponent Clone();
}