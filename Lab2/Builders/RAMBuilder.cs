using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class RAMBuilder
{
    private int _availableMemory;
    private int _supportedJedec;
    private IReadOnlyList<string>? _availableXmpProfiles;
    private string? _formFactor;
    private int _ddrVersion;
    private int _powerConsumption;
    private string? _name;

    public RAMBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public RAMBuilder WithAvailableMemory(int availableMemory)
    {
        _availableMemory = availableMemory;
        return this;
    }

    public RAMBuilder WithSupportedJEDEC(int supportedJedec)
    {
        _supportedJedec = supportedJedec;
        return this;
    }

    public RAMBuilder WithAvailableXMPProfiles(IReadOnlyList<string> availableXmpProfiles)
    {
        _availableXmpProfiles = availableXmpProfiles;
        return this;
    }

    public RAMBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public RAMBuilder WithDDRVersion(int ddrVersion)
    {
        _ddrVersion = ddrVersion;
        return this;
    }

    public RAMBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public RAM Build()
    {
        return new RAM(
            _availableMemory,
            _supportedJedec,
            _availableXmpProfiles ?? throw new ArgumentNullException(nameof(_availableXmpProfiles)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _ddrVersion,
            _powerConsumption,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}