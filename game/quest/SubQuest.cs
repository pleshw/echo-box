using Serializable;

namespace Game;

public class SubQuest(SerializableSubQuest serializableSubQuest) : ISerializableSubQuest
{

  public string Id { get; set; } = serializableSubQuest.Id;


  public string Title { get; set; } = serializableSubQuest.Title;


  public string Description { get; set; } = serializableSubQuest.Description;

  public QuestTask Task { get; set; } = serializableSubQuest.Task;
}
