namespace Quest;

public class QuestStepTaskHunt : ISerializableQuestStepTask
{
  public QuestStepTaskType TaskType { get; } = QuestStepTaskType.HUNT;
  public required int AmountToComplete;
  public required string NPCInfoFilePath;
}