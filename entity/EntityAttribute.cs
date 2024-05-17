using System.Text.Json.Serialization;

namespace Entity;

public abstract class EntityAttribute
{
  [JsonInclude]
  public abstract int Points { get; set; }

  [JsonInclude]
  public abstract string Name { get; set; }

  [JsonInclude]
  public abstract string Abbreviation { get; set; }
}