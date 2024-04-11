using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class CoolingSystem
{
    public CoolingSystem(CoolingCaseDimentions? dimensions, IReadOnlyList<string> supportedSockets, int maxTdp, string name)
    {
        Dimensions = dimensions;
        SupportedSockets = supportedSockets;
        MaxTDP = maxTdp;
        Name = name;
    }

    public CoolingCaseDimentions? Dimensions { get; }
    public IReadOnlyList<string> SupportedSockets { get; }
    public int MaxTDP { get; }
    public string Name { get; }

    public CoolingSystemBuilder? Direct(CoolingSystemBuilder coolingSystemBuilder)
    {
        coolingSystemBuilder?
            .WithName(Name)
            .WithDimensions(Dimensions)
            .WithMaxTdp(MaxTDP)
            .WithSupportedSockets(SupportedSockets);

        return coolingSystemBuilder;
    }
}