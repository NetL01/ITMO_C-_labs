using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class GraphicsCardBuilder
{
    private GraphicsCardDimentions? _graphicsCardSize;
    private int _videoMemorySize;
    private int _pciExpressVersion;
    private int _chipFrequency;
    private int _powerConsumption;
    private string? _name;

    public GraphicsCardBuilder WithGraphicsCardSize(GraphicsCardDimentions graphicsCardSize)
    {
        _graphicsCardSize = graphicsCardSize;
        return this;
    }

    public GraphicsCardBuilder WithVideoMemorySize(int videoMemorySize)
    {
        _videoMemorySize = videoMemorySize;
        return this;
    }

    public GraphicsCardBuilder WithPciExpressVersion(int pciExpressVersion)
    {
        _pciExpressVersion = pciExpressVersion;
        return this;
    }

    public GraphicsCardBuilder WithChipFrequency(int chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public GraphicsCardBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public GraphicsCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public GraphicsCard Build()
    {
        return new GraphicsCard(
            _graphicsCardSize ?? throw new ArgumentNullException(nameof(_graphicsCardSize)),
            _videoMemorySize,
            _pciExpressVersion,
            _chipFrequency,
            _powerConsumption,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}