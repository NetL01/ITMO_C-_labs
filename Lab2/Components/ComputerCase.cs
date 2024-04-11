using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class ComputerCase
{
    public ComputerCase(CaseDimentions maxVideoCardSize, int supportedMotherboardFormFactors, CaseDimentions? dimensions, string name)
    {
        MaxVideoCardSize = maxVideoCardSize;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
        Name = name;
    }

    public CaseDimentions MaxVideoCardSize { get; }
    public int SupportedMotherboardFormFactors { get; }
    public CaseDimentions? Dimensions { get; }
    public string Name { get; }

    public ComputerCaseBuilder? Direct(ComputerCaseBuilder computerCaseBuilder)
    {
        computerCaseBuilder?
            .WithName(Name)
            .WithDimensions(Dimensions)
            .WithMaxVideoCardSize(MaxVideoCardSize)
            .WithSupportedMotherboardFormFactors(SupportedMotherboardFormFactors);

        return computerCaseBuilder;
    }
}