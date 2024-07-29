namespace Game;

public class AnimatedBodyComponent : IAnimatedBodyComponent
{
  public required Dictionary<string, IBodyPartComponent> PartsByComponent { get; set; }
}