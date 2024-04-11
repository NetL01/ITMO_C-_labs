using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class ComputerCaseRepository : IRepository<ComputerCase>
{
    private static ComputerCaseRepository? _instance;
    private Collection<ComputerCase> _computerCase;

    private ComputerCaseRepository()
    {
        _computerCase = new();
        ComputerCase computerCase = new ComputerCaseBuilder()
            .WithDimensions(new CaseDimentions(12, 12))
            .WithName("STEELSERIES")
            .WithMaxVideoCardSize(new CaseDimentions(150, 150))
            .WithSupportedMotherboardFormFactors(140)
            .Build();

        _computerCase.Add(computerCase);
    }

    public static ComputerCaseRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new ComputerCaseRepository();
            return _instance;
        }
    }

    public void Add(ComputerCase newComponent)
    {
        _computerCase.Add(newComponent);
    }

    public ComputerCase? Receive(string name)
    {
        foreach (ComputerCase computerCase in _computerCase)
        {
            if (name == computerCase.Name) return computerCase;
        }

        return null;
    }
}