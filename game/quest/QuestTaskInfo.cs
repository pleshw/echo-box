using Serializable;

namespace Game;

public abstract class QuestTaskInfo(Entity assignedTo) : SerializableQuestTaskInfo, ICompletable
{
  public required DateTime StartedAt;

  public Entity AssignedTo = assignedTo;

  public override abstract QuestTaskType TaskType { get; }

  public abstract bool IsReadyToComplete { get; }

  public abstract void Complete();
}