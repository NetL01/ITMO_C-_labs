using Itmo.ObjectOrientedProgramming.Lab3.Essences;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class DisplayAddressee : IAddressee
{
    private readonly IMessageDisplay _display;

    public DisplayAddressee(IMessageDisplay display)
    {
        _display = display;
    }

    public void SendMessage(IMessage message)
    {
        _display.Output(message);
    }
}