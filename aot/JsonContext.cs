using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;
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
JsonSerializable(typeof(SerializableQuestTask)), JsonSerializable(typeof(List<SerializableQuestTask>)),
JsonSerializable(typeof(SerializableQuestTaskInfo)),
JsonSerializable(typeof(List<SerializableQuestTaskInfo>)),
JsonSerializable(typeof(QuestTaskType)),
JsonSerializable(typeof(SerializableQuestTask)), JsonSerializable(typeof(List<SerializableQuestTask>)),
JsonSerializable(typeof(SerializableQuestTaskCollection)),
JsonSerializable(typeof(SerializableQuestTaskHunt)),
JsonSerializable(typeof(SerializableQuestTaskFind)),
JsonSerializable(typeof(SerializableQuestTaskEscort)),
JsonSerializable(typeof(SerializableQuestTaskReachPosition)),
JsonSerializable(typeof(SerializableQuestTaskReachEntity)),
JsonSerializable(typeof(Vector2)),
JsonSerializable(typeof(SerializableNPC)),
JsonSerializable(typeof(ISerializableSubQuest)),
JsonSerializable(typeof(List<ISerializableSubQuest>))
]
[JsonSerializable(typeof(string)), JsonSerializable(typeof(Dictionary<string, string>)), JsonSerializable(typeof(List<string>)), JsonSerializable(typeof(List<string[]>)), JsonSerializable(typeof(float)), JsonSerializable(typeof(List<float>)), JsonSerializable(typeof(bool)), JsonSerializable(typeof(List<bool>))]
public partial class JsonContext : JsonSerializerContext
{
}