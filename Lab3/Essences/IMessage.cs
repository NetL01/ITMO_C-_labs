namespace Itmo.ObjectOrientedProgramming.Lab3.Essences;

public interface IMessage
{
    string Title { get; }
    string Body { get; }
    public string Id { get; }
    int Importance { get; }
    string WriteMessage();
}