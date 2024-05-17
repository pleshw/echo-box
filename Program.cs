using System.Diagnostics.CodeAnalysis;
using Dialogue;
using Main;

namespace EchoBox;

[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static class Program
{
  private static void Main(string[] args)
  {
    NPCBox.MakeCompleteTestNPC();
  }
}
