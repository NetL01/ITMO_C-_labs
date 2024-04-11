using System;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver;

public interface IDisplayDriver
{
    void Clear();
    void SetColor(ConsoleColor color);
    void Output(IMessage message);
}