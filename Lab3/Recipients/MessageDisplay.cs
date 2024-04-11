using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class MessageDisplay : IMessageDisplay
{
    private IDisplayDriver _displayDriver;

    public MessageDisplay(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void Output(IMessage message)
    {
        _displayDriver.Output(message);
    }
}