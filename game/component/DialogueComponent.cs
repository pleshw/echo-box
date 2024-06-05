
namespace Game;

public class DialogueComponent() : IDialogueComponent
{
  public required List<IDialogueBriefingComponent> Next { get; set; }
  public required string Title { get; set; }
  public required string Content { get; set; }

  public required Guid Id { get; set; }

  public required bool AlreadyCompleted { get; set; }

  public required bool IsReadyToComplete { get; set; }

  // public DialogueComponent(DialogueComponent other) : this()
  // {
  //   ArgumentNullException.ThrowIfNull(other);

  //   Next = [.. other.Next];
  //   Title = other.Title;
  //   Content = other.Content;
  //   Id = other.Id;
  //   AlreadyCompleted = other.AlreadyCompleted;
  //   IsReadyToComplete = other.IsReadyToComplete;
  // }

  public void Cancel()
  {
    throw new NotImplementedException();
  }

  public void Complete()
  {
    throw new NotImplementedException();
  }
}