using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyList<IAddressee> _recipients;

    public GroupAddressee(IReadOnlyList<IAddressee> recipients)
    {
        _recipients = recipients;
    }

    public void SendMessage(IMessage message)
    {
        foreach (IAddressee recipient in _recipients)
        {
            recipient.SendMessage(message);
        }
    }
}