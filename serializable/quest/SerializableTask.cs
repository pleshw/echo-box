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


[JsonConverter(typeof(JsonQuestTaskConverter))]
public abstract class SerializableQuestTask
{
  public abstract QuestTaskType TaskType { get; }
}