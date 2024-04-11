using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
        {
            _messenger = messenger;
        }

    public void SendMessage(IMessage message)
    {
        _messenger.Send(message);
    }
}