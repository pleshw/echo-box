
namespace Game;

public class DialogueBriefingComponent : IDialogueBriefingComponent
{
  public required Guid Id { get; set; }

  public required string Title { get; set; }

  public required IIdComponent Dialogue { get; set; }
}