using System.Text.Json.Serialization;
using Quest;

namespace Dialogue;

public record class SerializableDialogueRestrictions
{
  [JsonInclude]
  public bool OnlyAvailableOnFirstInteraction;

  [JsonInclude]
  public bool OnlyAvailableAfterFirstInteraction;

  [JsonInclude]
  public bool OnlyAvailableByNight;

  [JsonInclude]
  public bool OnlyAvailableByDay;

  [JsonInclude]
  public List<string>? RequiredCompletedQuests;

  [JsonInclude]
  public List<string>? RequiredOngoingQuests;
}
