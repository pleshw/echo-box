using System.Text.Json.Serialization;

namespace Quest;

public record class SerializableQuest
{
  [JsonInclude]
  public required string Id;

  [JsonInclude]
  public required string Title;

  [JsonInclude]
  public required string Description;

  [JsonInclude]
  public required List<SerializableQuestStep> QuestSteps;
}