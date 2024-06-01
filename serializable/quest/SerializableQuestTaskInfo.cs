using System.Text.Json.Serialization;
using AOT;

namespace Serializable;

public enum QuestTaskType
{
  COLLECTION,
  HUNT,
  FIND,
  ESCORT,
  REACH_POSITION,
  REACH_NPC
}


[JsonConverter(typeof(JsonQuestTaskInfoConverter))]
public abstract class SerializableQuestTaskInfo
{
  public abstract QuestTaskType TaskType { get; }
}