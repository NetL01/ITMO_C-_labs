using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public interface IMessageDisplay
{
    void Output(IMessage message);
}