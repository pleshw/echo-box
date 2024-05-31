namespace Serializable;

public static partial class Attributes
{
  public class Agility : SerializableAttribute
  {
    public override int Points { get; set; } = 0;

    public override string Abbreviation { get; set; } = "agi";

    public override string Name { get; set; } = "Agility";
  }

  public class Dexterity : SerializableAttribute
  {
    public override int Points { get; set; } = 0;

    public override string Abbreviation { get; set; } = "dex";

    public override string Name { get; set; } = "Dexterity";
  }

  public class Intelligence : SerializableAttribute
  {
    public override int Points { get; set; } = 0;

    public override string Abbreviation { get; set; } = "int";

    public override string Name { get; set; } = "Intelligence";
  }

  public class Luck : SerializableAttribute
  {
    public override int Points { get; set; } = 0;

    public override string Abbreviation { get; set; } = "luk";

    public override string Name { get; set; } = "Luck";
  }

  public class Strength : SerializableAttribute
  {
    public override int Points { get; set; } = 0;

    public override string Abbreviation { get; set; } = "str";

    public override string Name { get; set; } = "Strength";
  }

  public class Vitality : SerializableAttribute
  {
    public override int Points { get; set; } = 0;

    public override string Abbreviation { get; set; } = "vit";

    public override string Name { get; set; } = "Vitality";
  }
}