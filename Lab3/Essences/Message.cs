namespace Itmo.ObjectOrientedProgramming.Lab3.Essences;

public class Message : IMessage
{
    public Message(string title, string body, string id, int importance)
    {
        Title = title;
        Body = body;
        Id = id;
        Importance = importance;
    }

    public string Title { get; }
    public string Body { get; }
    public string Id { get; }
    public int Importance { get; }

    public string WriteMessage()
    {
        return $"{Title} \n{Body}";
    }
}