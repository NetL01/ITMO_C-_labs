using Itmo.ObjectOrientedProgramming.Lab3.Essences;
using Itmo.ObjectOrientedProgramming.Lab3.Logging;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class LoggerAddressee : IAddressee
{
    private ILogger _logger;
    private IAddressee _addressee;

    public LoggerAddressee(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void SendMessage(IMessage message)
    {
        _addressee.SendMessage(message);
        _logger.Log(message);
    }
}