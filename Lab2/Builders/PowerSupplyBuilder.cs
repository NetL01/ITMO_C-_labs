using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class PowerSupplyBuilder
{
    private decimal _power;
    private string? _name;

    public PowerSupplyBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public PowerSupplyBuilder WithPower(decimal power)
    {
        _power = power;
        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(
            _power,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}