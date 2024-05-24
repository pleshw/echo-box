using System.Text.Json.Serialization;
using AOT;

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


[JsonConverter(typeof(JsonQuestStepTaskConverter))]
public abstract class SerializableQuestStepTask
{
  public abstract QuestStepTaskType TaskType { get; }
}