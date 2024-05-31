using System.Diagnostics.CodeAnalysis;
using Factory;
using Serializable;

namespace Game;


[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public class Quest(SerializableQuest original) : ISerializableQuest
{
  public string Id { get; set; } = original.Id;


  public string Title { get; set; } = original.Title;


  public string Description { get; set; } = original.Description;


  public List<SerializableSubQuest> SubQuests { get; set; } = original.SubQuests;

  public Quest(string filePath) : this(FileController.GetFileDeserialized<SerializableQuest>(filePath) ?? throw new Exception($"Invalid file path for creating Quest. File path: {filePath}"))
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
}