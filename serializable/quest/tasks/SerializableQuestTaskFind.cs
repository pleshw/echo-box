using Game;

namespace Serializable;

public class SerializableQuestTaskFind : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.FIND;
  public required string ItemInfoFilePath;
}