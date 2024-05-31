namespace Game;

public class QuestTaskReachNPC : QuestTask
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_NPC;
  public required string NPCInfoFilePath;
}