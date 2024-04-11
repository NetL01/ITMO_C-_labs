using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;
using Itmo.ObjectOrientedProgramming.Lab3.Essences.MessageResults;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public interface IUser
{
    Dictionary<string, bool> Messages { get; }
    void GetMessage(IMessage message);
    MessageResults ReadMessage(IMessage message);
}
