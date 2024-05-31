using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Factory;
using Serializable;
using SerializableAttribute = Serializable.SerializableAttribute;

namespace AOT;

[RequiresUnreferencedCode("Calls AOT.JsonQuestStepConverter.JsonQuestStepConverter()")]
[RequiresDynamicCode("Calls AOT.JsonQuestStepConverter.JsonQuestStepConverter()")]
[JsonSourceGenerationOptions(
    WriteIndented = true,
    IncludeFields = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(SerializableDialogue)),
JsonSerializable(typeof(SerializableDialogueNode)),
JsonSerializable(typeof(SerializableDialogueOption)),
JsonSerializable(typeof(SerializableDialogueRestrictions)),
JsonSerializable(typeof(SerializableAnimationBody)),
JsonSerializable(typeof(SerializableAttribute)),
JsonSerializable(typeof(SerializableEntity)),
JsonSerializable(typeof(SerializableEntityAttributes)),
JsonSerializable(typeof(SerializableInteraction)),
JsonSerializable(typeof(SerializableQuest)),
JsonSerializable(typeof(SerializableSubQuest)), JsonSerializable(typeof(List<SerializableSubQuest>)),
JsonSerializable(typeof(QuestTaskType)),
JsonSerializable(typeof(SerializableSubQuest)), JsonSerializable(typeof(List<SerializableSubQuest>)),
JsonSerializable(typeof(QuestTaskCollection)),
JsonSerializable(typeof(QuestTaskHunt)),
JsonSerializable(typeof(QuestTaskFind)),
JsonSerializable(typeof(QuestTaskEscort)),
JsonSerializable(typeof(QuestTaskReachPosition)),
JsonSerializable(typeof(QuestTaskReachNPC)),
JsonSerializable(typeof(Vector2)),
JsonSerializable(typeof(SerializableNPC))]
[JsonSerializable(typeof(string)), JsonSerializable(typeof(Dictionary<string, string>)), JsonSerializable(typeof(List<string>)), JsonSerializable(typeof(List<string[]>)), JsonSerializable(typeof(float)), JsonSerializable(typeof(List<float>)), JsonSerializable(typeof(bool)), JsonSerializable(typeof(List<bool>))]
public partial class JsonContext : JsonSerializerContext
{
}