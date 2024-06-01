namespace Serializable;

public interface ISerializableQuest
{
  string Id { get; set; }

  string Title { get; set; }

  string Description { get; set; }

  List<ISerializableSubQuest> SubQuests { get; set; }
}