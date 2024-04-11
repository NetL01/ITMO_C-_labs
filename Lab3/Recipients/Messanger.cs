using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class Messanger : IMessenger
{
    public void Send(IMessage message)
    {
        Console.WriteLine($"{message?.Title}\n{message?.Body} (Messanger)");
    }
}