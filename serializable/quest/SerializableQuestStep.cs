using System.Text.Json.Serialization;
using AOT;

namespace Serializable;

public record class SerializableSubQuest
{

  public required string Id;


  public required string Title;


  public required string Description;


  public required bool IsCompleted;


  public required SerializableQuestTask Task;
}