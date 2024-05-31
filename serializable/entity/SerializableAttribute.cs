namespace Serializable;

public abstract class SerializableAttribute
{

  public abstract int Points { get; set; }


  public abstract string Name { get; set; }


  public abstract string Abbreviation { get; set; }
}