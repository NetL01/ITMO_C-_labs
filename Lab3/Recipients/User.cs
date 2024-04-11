using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;
using Itmo.ObjectOrientedProgramming.Lab3.Essences.MessageResults;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class User : IUser
{
    public Dictionary<string, bool> Messages { get; } = new();

    public void GetMessage(IMessage message)
    {
        if (message?.Id != null)
        {
            Messages[message.Id] = false;
        }
    }

    public MessageResults ReadMessage(IMessage message)
    {
        if (message?.Id != null)
        {
            if (Messages[message.Id])
            {
                Console.WriteLine("Сообщение уже прочитано!");
                return MessageResults.AlreadyRead;
            }

            Messages[message.Id] = true;
            return MessageResults.SuccessfullyRead;
        }

        return MessageResults.Fail;
    }
}