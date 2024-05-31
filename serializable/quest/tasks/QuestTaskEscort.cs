namespace Serializable;

public class QuestTaskEscort : SerializableQuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.ESCORT;
  public required string DestinationInfoFilePath;
  public required string NPCInfoFilePath;
}