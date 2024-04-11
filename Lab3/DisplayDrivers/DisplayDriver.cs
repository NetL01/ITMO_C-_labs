using System;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver;

public class DisplayDriver : IDisplayDriver
{
    private ConsoleColor _color;

    public DisplayDriver(ConsoleColor color)
    {
        _color = color;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(ConsoleColor color)
    {
        _color = color;
    }

    public void Output(IMessage message)
    {
        Console.ForegroundColor = _color;
        Console.WriteLine($"{message?.Title}\n{message?.Body} (Display)");
        Console.ResetColor();
    }
}