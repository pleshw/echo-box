using System.Numerics;
using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

public class GatherComponent : IGatherComponent
{
  public required IItemComponent Resource { get; set; }

  public required Vector2 Position { get; set; }

  public required int TimeToRenew { get; set; }

  public required DateTime? CompletedAt { get; set; }

  public required int Amount { get; set; }

  public required int TotalProgress { get; set; }

  public required int CurrentProgress { get; set; }

  public required int RequiredLevel { get; set; }

  public required Dictionary<MasteryTypes, int> LevelByRequiredMastery { get; set; }
}