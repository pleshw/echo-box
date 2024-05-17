using Entity;
using Dialogue;
using static Entity.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Main;


[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static class NPCBox
{
    public static void MakeCompleteTestNPC()
    {
        SerializableNPC npc = new()
        {
            DisplayName = "Test complete npc",
            Level = 3,
            Body = (SerializableAnimationBody)new Dictionary<string, string>()
            {
                {"Hat", "res://resources/test/body/test_hat.tres"},
                {"Body", "res://resources/test/body/test_body.tres"}
            },
            Attributes = new SerializableEntityAttributes { Agility = new Agility() { Points = 3 } },
            NodePath = "res://prefabs/test/npc_test.tscn",
            Dialogue = new SerializableDialogue
            {
                NodePath = "res://data/test/dialogue/test_dialogue.json",
                Title = "Test Dialogue",
                DefaultDialogueNodePath = "res://data/test/dialogue/nodes/test_default_dialogue.json",
                FirstInteractionDialogueNodePath = "res://data/test/dialogue/nodes/test_first_interaction_dialogue.json"
            },
            CurrentTile = new Vector2
            {
                X = 3,
                Y = 3
            },
        };

        FileController.CreateProjectFile("npc_test.json", npc);
    }
}