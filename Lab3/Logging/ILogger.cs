using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public interface ILogger
{
    void Log(IMessage message);
}