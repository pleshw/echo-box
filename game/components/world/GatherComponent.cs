using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class GatherComponent : IGatherComponent
{
  public required IItemComponent Resource { get; set; }

  public required int TimeToRenew { get; set; }

  public required int CurrentTimer { get; set; }

  public required int Amount { get; set; }

  public required int TotalProgress { get; set; }

  public required int CurrentProgress { get; set; }
}