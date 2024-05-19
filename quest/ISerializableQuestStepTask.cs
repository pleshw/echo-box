using System.Text.Json.Serialization;

namespace Quest;

public enum QuestStepTaskType
{
  COLLECTION,
  HUNT,
  FIND,
  ESCORT,
  REACH_POSITION,
  REACH_NPC
}


public interface ISerializableQuestStepTask
{
  public QuestStepTaskType TaskType { get; }
}