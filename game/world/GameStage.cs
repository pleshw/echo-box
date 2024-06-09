using System.Text.Json.Serialization;

namespace Game;

public abstract class GameStage : IStageComponent
{
  public abstract string UniqueName { get; set; }

  public abstract List<IUniqueNameComponent> EntityList { get; set; }
}