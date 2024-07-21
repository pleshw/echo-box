using Build;
using Game;


namespace EchoBox;

public static class Program
{
  private static void Main(string[] _)
  {
    var playerBuilder = new PlayerActorBuild();
    var player = playerBuilder.LoadFile();
  }
}
