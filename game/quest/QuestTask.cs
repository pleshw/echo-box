using System.Text.Json.Serialization;
using AOT;

namespace Game;

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
public abstract class QuestTask
{
  public abstract QuestTaskType TaskType { get; }
}