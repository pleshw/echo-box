namespace Quest;

public class QuestStepTaskReachNPC : ISerializableQuestStepTask
{
  public QuestStepTaskType TaskType { get; } = QuestStepTaskType.COLLECTION;
  public required string NPCInfoFilePath;
}