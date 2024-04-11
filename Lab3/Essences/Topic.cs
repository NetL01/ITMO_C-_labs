using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Essences;

public class Topic : ITopic
{
    public Topic(string name, IAddressee recipients)
    {
        Name = name;
        Recipients = recipients;
    }

    public string Name { get; }
    public IAddressee Recipients { get; }

    public void SendMessage(IMessage message)
    {
        Recipients.SendMessage(message);
    }
}