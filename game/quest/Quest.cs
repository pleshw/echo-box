using System.Diagnostics.CodeAnalysis;
using Factory;
using Serializable;

namespace Game;

public class Quest(GameEntity assignedTo, SerializableQuest serializableQuest) : IQuestComponent, ICompletableComponent
{
  public GameEntity AssignedTo = assignedTo;

  public string Id { get; set; } = serializableQuest.Id;

  public string Title { get; set; } = serializableQuest.Title;

  public string Description { get; set; } = serializableQuest.Description;

  public List<ITaskComponent> Tasks { get; set; } = serializableQuest.Tasks;

  public bool IsReadyToComplete
  {
    get
    {
      return Tasks.OfType<IAssignedTaskComponent>().All(s => s.IsReadyToComplete);
    }
  }

  public Quest(GameEntity assignedTo, string filePath) : this(assignedTo, FileController.GetFileDeserialized<SerializableQuest>(filePath) ?? throw new Exception($"Invalid file path for creating Quest. File path: {filePath}"))
  {

  }

  public event Action? OnQuestComplete;
  public void QuestCompleteEvent()
  {
    OnQuestComplete?.Invoke();
  }

  public event Action? OnQuestStart;
  public void QuestStartEvent()
  {
    OnQuestStart?.Invoke();
  }

  public event Action? OnQuestCancel;
  public void QuestCancelEvent()
  {
    OnQuestCancel?.Invoke();
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}