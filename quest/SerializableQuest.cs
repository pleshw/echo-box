using System.Text.Json.Serialization;

namespace Quest;

public record class SerializableQuest
{

  public required string Id;


  public required string Title;


  public required string Description;


  public required List<SerializableQuestStep> QuestSteps;
}