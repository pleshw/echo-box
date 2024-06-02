using System.ComponentModel;
using Game;

namespace Game;

public abstract class GameEntity : ISharedNameComponent
{
  public string SharedName { get; set; }

  public abstract List<Type> RequiredComponents { get; }

  private readonly Dictionary<Type, IComponent> _components = [];

  public GameEntity(string id)
  {
    SharedName = id;
  }

  public GameEntity(string id, List<IComponent> components)
  {
    SharedName = id;

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
      throw new Exception($"Component {typeof(T)} does not exist in this entity. Entity Id: {SharedName}");
    }

    return (T)component;
  }

  public void RemoveComponent<T>() where T : IComponent
  {
    _components.Remove(typeof(T));
  }

  public abstract IComponent Clone();
}