using System.Text.Json.Serialization;

namespace Quest;

public record class SerializableQuestStep
{
  [JsonInclude]
  public required string Id;

  [JsonInclude]
  public required string Title;

  [JsonInclude]
  public required string Description;

  [JsonInclude]
  public required bool IsCompleted;
}