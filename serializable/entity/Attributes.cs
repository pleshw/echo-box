namespace Serializable;

public static partial class Attributes
{
  public class Agility : ISerializableAttribute
  {
    public int Points { get; set; } = 0;

    public string Abbreviation { get; set; } = "agi";

    public string Name { get; set; } = "Agility";
  }

  public class Dexterity : ISerializableAttribute
  {
    public int Points { get; set; } = 0;

    public string Abbreviation { get; set; } = "dex";

    public string Name { get; set; } = "Dexterity";
  }

  public class Intelligence : ISerializableAttribute
  {
    public int Points { get; set; } = 0;

    public string Abbreviation { get; set; } = "int";

    public string Name { get; set; } = "Intelligence";
  }

  public class Luck : ISerializableAttribute
  {
    public int Points { get; set; } = 0;

    public string Abbreviation { get; set; } = "luk";

    public string Name { get; set; } = "Luck";
  }

  public class Strength : ISerializableAttribute
  {
    public int Points { get; set; } = 0;

    public string Abbreviation { get; set; } = "str";

    public string Name { get; set; } = "Strength";
  }

  public class Vitality : ISerializableAttribute
  {
    public int Points { get; set; } = 0;

    public string Abbreviation { get; set; } = "vit";

    public string Name { get; set; } = "Vitality";
  }
}