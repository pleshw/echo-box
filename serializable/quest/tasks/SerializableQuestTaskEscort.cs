using Game;

namespace Serializable;

public class SerializableQuestTaskEscort : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.ESCORT;
  public required string DestinationInfoFilePath;
  public required string NPCInfoFilePath;
}