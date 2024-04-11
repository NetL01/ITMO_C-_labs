using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class BIOS
{
    public BIOS(string type, string version, IReadOnlyList<string>? supportedProcessors, string name)
    {
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
        Name = name;
    }

    public string Type { get; }
    public string Version { get; }
    public IReadOnlyList<string>? SupportedProcessors { get; }
    public string Name { get; }

    public BIOSBuilder? Direct(BIOSBuilder biosBuilder)
    {
        biosBuilder?
            .WithName(Name)
            .WithType(Type)
            .WithVersion(Version)
            .WithSupportedProcessors(SupportedProcessors);

        return biosBuilder;
    }
}