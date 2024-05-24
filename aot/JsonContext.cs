using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dialogue;
using Entity;
using Main;
using Quest;
using SerializableAttribute = Entity.SerializableAttribute;

namespace AOT;

[RequiresUnreferencedCode("Calls AOT.JsonQuestStepConverter.JsonQuestStepConverter()")]
[RequiresDynamicCode("Calls AOT.JsonQuestStepConverter.JsonQuestStepConverter()")]
[JsonSourceGenerationOptions(
    WriteIndented = true,
    IncludeFields = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(SerializableDialogue)),
JsonSerializable(typeof(SerializableDialogueNode)),
JsonSerializable(typeof(SerializableDialogueOption)),
JsonSerializable(typeof(SerializableDialogueRestrictions)),
JsonSerializable(typeof(SerializableAnimationBody)),
JsonSerializable(typeof(SerializableAttribute)),
JsonSerializable(typeof(SerializableEntity)),
JsonSerializable(typeof(SerializableEntityAttributes)),
JsonSerializable(typeof(SerializableInteraction)),
JsonSerializable(typeof(SerializableQuestStep)),
JsonSerializable(typeof(QuestStepTaskCollection)),
JsonSerializable(typeof(QuestStepTaskHunt)),
JsonSerializable(typeof(QuestStepTaskFind)),
JsonSerializable(typeof(QuestStepTaskEscort)),
JsonSerializable(typeof(QuestStepTaskReachPosition)),
JsonSerializable(typeof(QuestStepTaskReachNPC)),
JsonSerializable(typeof(Vector2)),
JsonSerializable(typeof(SerializableNPC))]
[JsonSerializable(typeof(string)), JsonSerializable(typeof(Dictionary<string, string>)), JsonSerializable(typeof(List<string>)), JsonSerializable(typeof(List<string[]>)), JsonSerializable(typeof(float)), JsonSerializable(typeof(List<float>)), JsonSerializable(typeof(bool)), JsonSerializable(typeof(List<bool>))]
public partial class JsonContext : JsonSerializerContext
{
}