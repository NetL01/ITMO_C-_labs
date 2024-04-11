using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class SSDBuilder
{
    private string? _connectionType;
    private int _capacity;
    private int _maxSpeed;
    private int _powerConsumption;
    private string? _name;

    public SSDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public SSDBuilder WithConnectionType(string connectionType)
    {
        _connectionType = connectionType;
        return this;
    }

    public SSDBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public SSDBuilder WithMaxSpeed(int maxSpeed)
    {
        _maxSpeed = maxSpeed;
        return this;
    }

    public SSDBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public SSD Build()
    {
        return new SSD(
            _capacity,
            _maxSpeed,
            _powerConsumption,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}