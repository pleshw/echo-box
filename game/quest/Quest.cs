using System.Diagnostics.CodeAnalysis;
using Factory;
using Serializable;

namespace Game;


[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public class Quest(SerializableQuest serializableQuest) : ISerializableQuest
{
  public string Id { get; set; } = serializableQuest.Id;

  public string Title { get; set; } = serializableQuest.Title;

  public string Description { get; set; } = serializableQuest.Description;

  public List<SerializableSubQuest> SubQuests { get; set; } = serializableQuest.SubQuests;

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