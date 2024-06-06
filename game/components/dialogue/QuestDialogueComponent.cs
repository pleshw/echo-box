using System.Text.Json.Serialization;
using JSONConverters;

namespace Game;

[JsonConverter(typeof(JsonQuestDialogueConverter))]
public class QuestDialogueComponent : DialogueComponent, IQuestDialogueComponent
{
  public required IIdComponent Quest { get; set; }
}