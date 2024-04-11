using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class HDDBuilder
{
    private int _capacity;
    private int _spindleSpeed;
    private int _powerConsumption;
    private string? _name;

    public HDDBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public HDDBuilder WithCapacity(int capacity)
    {
        _capacity = capacity;
        return this;
    }

    public HDDBuilder WithSpindleSpeed(int spindleSpeed)
    {
        _spindleSpeed = spindleSpeed;
        return this;
    }

    public HDDBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public HDD Build()
    {
        return new HDD(
            _spindleSpeed,
            _capacity,
            _powerConsumption,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}