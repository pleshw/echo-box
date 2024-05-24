using System.Text.Json.Serialization;
using AOT;

namespace Quest;

public record class SerializableQuestStep
{

  public required string Id;


  public required string Title;


  public required string Description;


  public required bool IsCompleted;


  public required SerializableQuestStepTask Task;
}