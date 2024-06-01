using Serializable;

namespace Game;

public class QuestTaskReachEntity(Entity assignedTo) : QuestTaskInfo(assignedTo)
{
  public override QuestTaskType TaskType { get; } = QuestTaskType.REACH_NPC;

  public string? DialogueIdCompleteQuest;

  public EntityInfo EntityInfo;

  public override bool IsReadyToComplete
  {
    get
    {
      RelationshipInfo relationshipInfo = EntityInfo.GetRelationshipInfo(EntityInfo.Id);

      if (StartedAt > relationshipInfo.LastInteraction)
      {
        return false;
      }

      if (DialogueIdCompleteQuest == null)
      {
        return true;
      }

      return relationshipInfo.CompletedDialogue(DialogueIdCompleteQuest);
    }
  }

  public override void Complete()
  {
    throw new NotImplementedException();
  }
}