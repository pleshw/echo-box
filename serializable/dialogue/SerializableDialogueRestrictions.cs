using System.Text.Json.Serialization;
using Serializable;

namespace Serializable;

public record class SerializableDialogueRestrictions
{

  public bool OnlyAvailableOnFirstInteraction;


  public bool OnlyAvailableAfterFirstInteraction;


  public bool OnlyAvailableByNight;


  public bool OnlyAvailableByDay;


  public List<string>? RequiredCompletedQuests;


  public List<string>? RequiredOngoingQuests;
}
