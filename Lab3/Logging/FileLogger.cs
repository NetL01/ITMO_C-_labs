using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Essences;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logging;

public class FileLogger : ILogger
{
    private string _path = "D:\\C# labs\\NetL01\\src\\Lab3\\Logs.txt";

    public void Log(IMessage message)
    {
        using (var sw = new StreamWriter(_path))
        {
            sw.Write(message?.WriteMessage());
        }
    }
}