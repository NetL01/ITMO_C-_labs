using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class GraphicsCard
{
    public GraphicsCard(GraphicsCardDimentions graphicsCardSize, int videomemorySize, int pciExpressVersion, int chipFrequency, int powerConsumption, string name)
    {
        GraphicsCardSize = graphicsCardSize;
        VideoMemorySize = videomemorySize;
        PciExpressVersion = pciExpressVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public GraphicsCardDimentions GraphicsCardSize { get; }
    public int VideoMemorySize { get; }
    public int PciExpressVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
    public string Name { get; }

    public GraphicsCardBuilder? Direct(GraphicsCardBuilder graphicsCardBuilder)
    {
        graphicsCardBuilder?
            .WithName(Name)
            .WithChipFrequency(ChipFrequency)
            .WithPowerConsumption(PowerConsumption)
            .WithGraphicsCardSize(GraphicsCardSize)
            .WithPciExpressVersion(PciExpressVersion)
            .WithVideoMemorySize(VideoMemorySize);

        return graphicsCardBuilder;
    }
}