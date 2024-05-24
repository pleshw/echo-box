namespace Quest;

public class QuestStepTaskEscort : SerializableQuestStepTask
{
  public override QuestStepTaskType TaskType { get; } = QuestStepTaskType.ESCORT;
  public required string DestinationInfoFilePath;
  public required string NPCInfoFilePath;
}