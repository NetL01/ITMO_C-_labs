using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ComputerCaseBuilder
{
    private CaseDimentions? _maxVideoCardSize;
    private int _supportedMotherboardFormFactors;
    private CaseDimentions? _dimensions;
    private string? _name;

    public ComputerCaseBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ComputerCaseBuilder WithMaxVideoCardSize(CaseDimentions maxVideoCardSize)
    {
        _maxVideoCardSize = maxVideoCardSize;
        return this;
    }

    public ComputerCaseBuilder WithSupportedMotherboardFormFactors(int supportedMotherboardFormFactors)
    {
        _supportedMotherboardFormFactors = supportedMotherboardFormFactors;
        return this;
    }

    public ComputerCaseBuilder WithDimensions(CaseDimentions? dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ComputerCase Build()
    {
        return new ComputerCase(
            _maxVideoCardSize ?? throw new ArgumentNullException(nameof(_maxVideoCardSize)),
            _supportedMotherboardFormFactors,
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}