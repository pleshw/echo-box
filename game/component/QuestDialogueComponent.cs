using System.Text.Json.Serialization;
using JSONConverters;
using Serializable;
using Tests;

namespace Game;

[JsonConverter(typeof(JsonQuestDialogueConverter))]
public class QuestDialogueComponent : DialogueComponent, IQuestDialogueComponent
{
  public required IIdComponent Quest { get; set; }
}