namespace Serializable;

public class QuestTaskHunt : SerializableQuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.HUNT;
  public required int AmountToComplete;
  public required string NPCInfoFilePath;
}