using System;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class ConsoleLogger : ILogger
{
    public void Log(IMessage message)
    {
        Console.WriteLine(message?.WriteMessage());
    }
}