using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class CoolingSystemBuilder
{
    private CoolingCaseDimentions? _dimensions;
    private List<string>? _supportedSockets = new List<string>();
    private int _maxTdp;
    private string? _name;

    public CoolingSystemBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CoolingSystemBuilder WithDimensions(CoolingCaseDimentions? dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public CoolingSystemBuilder WithSupportedSockets(IReadOnlyList<string> sockets)
    {
        _supportedSockets?.AddRange(sockets);
        return this;
    }

    public CoolingSystemBuilder WithMaxTdp(int maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public CoolingSystem Build()
    {
        return new CoolingSystem(
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _supportedSockets ?? throw new ArgumentNullException(nameof(_supportedSockets)),
            _maxTdp,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}