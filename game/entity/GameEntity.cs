using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public abstract class GameEntity : IUniqueNameComponent
{
  public string UniqueName { get; set; }

  [JsonIgnore]
  public abstract List<Type> RequiredComponents { get; }

  [JsonIgnore]
  private readonly Dictionary<Type, IComponent> _components = [];

  [JsonInclude]
  public List<IComponent> Components
  {
    get
    {
      return [.. _components.Values];
    }
  }

  public GameEntity(string uniqueName)
  {
    UniqueName = uniqueName;
  }

  [JsonConstructor]
  public GameEntity(string uniqueName, List<IComponent> components)
  {
    UniqueName = uniqueName;

    foreach (var component in components)
    {
      _components[component.GetType()] = component;
    }

    if (!HasRequiredComponents)
    {
      throw new Exception($"Entity {uniqueName} does not have the required components.");
    }
  }

  public void AddComponent(IComponent component)
  {
    _components[component.GetType()] = component;
  }

  public void AddComponent<T>(T component) where T : IComponent
  {
    _components[component.GetType()] = component;
  }

  [JsonIgnore]
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
      throw new Exception($"Component {typeof(T)} does not exist in this entity. Entity Id: {UniqueName}");
    }

    return (T)component;
  }

  public void RemoveComponent<T>() where T : IComponent
  {
    _components.Remove(typeof(T));
  }

  public abstract IComponent Clone();
}