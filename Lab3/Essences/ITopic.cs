using Itmo.ObjectOrientedProgramming.Lab3.Addressee;

namespace Itmo.ObjectOrientedProgramming.Lab3.Essences;

public interface ITopic
{
    string Name { get; }
    IAddressee Recipients { get; }
    void SendMessage(IMessage message);
}