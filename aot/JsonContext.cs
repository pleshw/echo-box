using System.Text.Json.Serialization;

namespace AOT;

[JsonSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.Unspecified,
    GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(string)), JsonSerializable(typeof(Dictionary<string, string>)), JsonSerializable(typeof(List<string>)), JsonSerializable(typeof(List<string[]>)), JsonSerializable(typeof(float)), JsonSerializable(typeof(List<float>)), JsonSerializable(typeof(bool)), JsonSerializable(typeof(List<bool>))]
internal partial class JsonContext : JsonSerializerContext
{
}