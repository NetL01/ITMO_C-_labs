using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class XmpProfile
{
    public XmpProfile(string timings, decimal voltage, int frequency, string name)
    {
        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
        Name = name;
    }

    public string Timings { get; }
    public decimal Voltage { get; }
    public int Frequency { get; }
    public string Name { get; }

    public XmpProfileBuilder? Direct(XmpProfileBuilder xmpProfileBuilder)
    {
        xmpProfileBuilder?
            .WithName(Name)
            .WithFrequency(Frequency)
            .WithTimings(Timings)
            .WithVoltage(Voltage);

        return xmpProfileBuilder;
    }
}