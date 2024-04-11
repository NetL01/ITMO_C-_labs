using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public interface IAddressee
{
    void SendMessage(IMessage message);
}