
namespace Game;

public record class CraftItemComponent : ICraftItemComponent
{
  public required List<IItemComponent> InputItemList { get; set; }

  public required bool IsHidden { get; set; }

  public required float Price { get; set; }

  public required IItemComponent Item { get; set; }

  public required IDisplayImageComponent FrameImage { get; set; }

  public required int RequiredLevel { get; set; }

  public void Hide()
  {
    throw new NotImplementedException();
  }

  public bool HideCondition()
  {
    throw new NotImplementedException();
  }

  public void Show()
  {
    throw new NotImplementedException();
  }
}