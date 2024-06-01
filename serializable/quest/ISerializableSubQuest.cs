namespace Serializable;

public interface ISerializableSubQuest
{

  public string Id { get; set; }


  public string Title { get; set; }


  public string Description { get; set; }

  public SerializableQuestTaskInfo TaskInfo { get; set; }
}