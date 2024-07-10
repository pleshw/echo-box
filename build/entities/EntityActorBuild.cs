using Game;

namespace Build;

public abstract class EntityActorBuild<T> : ICanSaveFileComponent, ICanLoadFileComponent<T>
where T : BaseEntity
{
  public abstract T Actor { get; }

  public void SaveFile()
  {
    FileController.CreateProjectFile(
                $"entity/{Actor.UniqueName}/",
                "actor.json",
                Actor
        );
  }

  public T LoadFile()
  {
    T? result = FileController.GetFileDeserialized<T>($"C:/Users/Usuário/Desktop/echo-box/data/entity/{Actor.UniqueName}/actor.json");

    if (result != null)
    {
      return result;
    }

    SaveFile();
    return Actor;
  }
}