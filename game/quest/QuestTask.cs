using Serializable;

namespace Game;

public class QuestTask(Entity assignedTo, SerializableQuestTask serializableSubQuest) : ISerializableSubQuest
{
  public Entity AssignedTo = assignedTo;

  public string Id { get; set; } = serializableSubQuest.Id;


  public string Title { get; set; } = serializableSubQuest.Title;


  public string Description { get; set; } = serializableSubQuest.Description;

  public required SerializableQuestTaskInfo TaskInfo { get; set; }
}
