using Game;

namespace Serializable;

public class SerializableQuestTaskHunt : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.HUNT;
  public required int AmountToComplete;
  public required string NPCInfoFilePath;
}