namespace Quest;

public class QuestStepTaskFind : SerializableQuestStepTask
{
  public override QuestStepTaskType TaskType { get; } = QuestStepTaskType.FIND;
  public required string ItemInfoFilePath;
}