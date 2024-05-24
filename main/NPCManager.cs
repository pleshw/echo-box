using Entity;
using Dialogue;
using static Entity.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Main;


[RequiresUnreferencedCode("")]
[RequiresDynamicCode("")]
public static class NPCManager
{
    public static void TestMakeCompleteNPC()
    {
        SerializableNPC npc = new()
        {
            NodePath = "res://prefabs/test/npc_test.tscn",
            DisplayName = "Test complete npc",
            Level = 3,
            Body = (SerializableAnimationBody)new Dictionary<string, string>()
            {
                {"Hat", "res://resources/test/body/test_hat.tres"},
                {"Body", "res://resources/test/body/test_body.tres"}
            },
            Attributes = new SerializableEntityAttributes { Agility = new Agility() { Points = 3 } },
            Dialogue = new SerializableDialogue
            {
                FolderPath = "res://data/dialogue/test/",
                FileName = "test_dialogue.json",
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