using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class RAM
{
    public RAM(int availableMemory, int supportedJedec, IReadOnlyList<string> availableXmpProfiles, string formFactor, int ddrVersion, int powerConsumption, string name)
    {
        AvailableMemory = availableMemory;
        SupportedJEDEC = supportedJedec;
        AvailableXMPProfiles = availableXmpProfiles;
        FormFactor = formFactor;
        DDRVersion = ddrVersion;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public int AvailableMemory { get; }
    public int SupportedJEDEC { get; }
    public IReadOnlyList<string> AvailableXMPProfiles { get; }
    public string FormFactor { get; }
    public int DDRVersion { get; }
    public int PowerConsumption { get; }
    public string Name { get; }

    public RAMBuilder? Direct(RAMBuilder ramBuilder)
    {
        ramBuilder?
            .WithName(Name)
            .WithFormFactor(FormFactor)
            .WithPowerConsumption(PowerConsumption)
            .WithAvailableMemory(AvailableMemory)
            .WithDDRVersion(DDRVersion)
            .WithAvailableXMPProfiles(AvailableXMPProfiles)
            .WithSupportedJEDEC(SupportedJEDEC);

        return ramBuilder;
    }
}