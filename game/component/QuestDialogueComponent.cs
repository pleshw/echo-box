
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class QuestDialogueComponent : IQuestDialogueComponent
{
  public required List<IIdComponent> Next { get; set; }

  public required string Title { get; set; }

  public required string Content { get; set; }

  public required Guid Id { get; set; }

  public required bool AlreadyCompleted { get; set; }

  public required bool IsReadyToComplete { get; set; }

  public required IIdComponent Quest { get; set; }

  public void Cancel()
  {
    throw new NotImplementedException();
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}