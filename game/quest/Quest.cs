using System.Diagnostics.CodeAnalysis;
using Factory;
using Serializable;

namespace Game;


[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public class Quest(Entity assignedTo, SerializableQuest serializableQuest) : ISerializableQuest, ICompletable
{
  public Entity AssignedTo = assignedTo;

  public string Id { get; set; } = serializableQuest.Id;

  public string Title { get; set; } = serializableQuest.Title;

  public string Description { get; set; } = serializableQuest.Description;

  public List<ISerializableSubQuest> SubQuests { get; set; } = serializableQuest.SubQuests;

  public bool IsReadyToComplete
  {
    get
    {
      return SubQuests.OfType<QuestTask>().All(s => ((QuestTaskInfo)s.TaskInfo).IsReadyToComplete);
    }
  }

  public Quest(Entity assignedTo, string filePath) : this(assignedTo, FileController.GetFileDeserialized<SerializableQuest>(filePath) ?? throw new Exception($"Invalid file path for creating Quest. File path: {filePath}"))
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