
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class DialogueBriefingComponent : IDialogueBriefingComponent
{
  public required Guid Id { get; set; }

  public required string Title { get; set; }
}