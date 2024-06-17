using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

[JsonConverter(typeof(JsonStageConverter))]
public class StageComponent : IStageComponent
{
  public required string UniqueName { get; set; }

  public required List<IUniqueNameComponent> EntityList { get; set; }

  public required IGridMapComponent GridMap { get; set; }

  public GridMapComponent GridMapComponent
  {
    get
    {
      return (GridMapComponent)GridMap;
    }
  }
}