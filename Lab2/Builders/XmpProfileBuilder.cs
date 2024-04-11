using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class XmpProfileBuilder
{
    private string? _timings;
    private decimal _voltage;
    private int _frequency;
    private string? _name;

    public XmpProfileBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public XmpProfileBuilder WithTimings(string timings)
    {
        _timings = timings;
        return this;
    }

    public XmpProfileBuilder WithVoltage(decimal voltage)
    {
        _voltage = voltage;
        return this;
    }

    public XmpProfileBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public XmpProfile Build()
    {
        return new XmpProfile(
            _timings ?? throw new ArgumentNullException(nameof(_timings)),
            _voltage,
            _frequency,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}