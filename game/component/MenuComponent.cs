namespace Game;

public class MenuComponent : IMenuComponent
{
  public required MenuType MenuType { get; set; }

  public required string UniqueName { get; set; }

  public required string DisplayName { get; set; }
}