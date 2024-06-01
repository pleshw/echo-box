namespace Game;

public interface ICompletable
{
  public abstract bool IsReadyToComplete { get; }

  public abstract void Complete();
}