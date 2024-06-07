


namespace Game;

public class RelationshipComponent : IRelationshipComponent
{
  public required List<IDialogueComponent> CompletedDialogs { get; set; }
  public required List<IDialogueComponent> NotSeenDialogs { get; set; }
  public required int Level { get; set; }
}