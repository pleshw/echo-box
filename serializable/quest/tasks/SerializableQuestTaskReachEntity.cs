namespace Serializable;

public class SerializableQuestTaskReachEntity : SerializableQuestTaskInfo
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_NPC;

  public string? DialogueIdCompleteQuest;

  public required string EntityInfoFilePath;
}