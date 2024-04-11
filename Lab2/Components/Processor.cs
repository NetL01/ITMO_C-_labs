using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Processor
{
    public Processor(int cores, string socket, bool integratedGraphics, int tdp, int powerConsumption, int frequency, int supportedMemoryFrequencies, string name)
    {
        Cores = cores;
        Socket = socket;
        IntegratedGraphics = integratedGraphics;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
        Frequency = frequency;
        SupportedMemoryFrequencies = supportedMemoryFrequencies;
        Name = name;
    }

    public int Frequency { get; }
    public int Cores { get; }
    public string Socket { get; }
    public bool IntegratedGraphics { get; }

    public int SupportedMemoryFrequencies { get; }
    public int Tdp { get; }

    public int PowerConsumption { get; }
    public string Name { get; }

    public ProcessorBuilder? Direct(ProcessorBuilder processorBuilder)
    {
        processorBuilder?
            .WithName(Name)
            .WithSocket(Socket)
            .WithPowerConsumption(PowerConsumption)
            .WithCores(Cores)
            .WithFrequency(Frequency)
            .WithTdp(Tdp)
            .WithIntegratedGraphics(IntegratedGraphics)
            .WithSupportedMemoryFrequencies(SupportedMemoryFrequencies);

        return processorBuilder;
    }
}