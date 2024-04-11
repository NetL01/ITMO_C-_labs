using System;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class FilterAddressee : IAddressee
{
    private int _filter;
    private IAddressee _addressee;

    public FilterAddressee(IAddressee addressee, int filter)
    {
        _addressee = addressee;
        _filter = filter;
    }

    public void SendMessage(IMessage message)
    {
        if (_filter <= message?.Importance)
        {
            _addressee.SendMessage(message);
        }
        else
        {
            Console.WriteLine("Важность сообщения слишком мала!");
        }
    }
}