using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class CoolingSystemRepository : IRepository<CoolingSystem>
{
    private static CoolingSystemRepository? _instance;
    private Collection<CoolingSystem> _coolingSystem;

    private CoolingSystemRepository()
    {
        _coolingSystem = new();
        CoolingSystem coolingSystem = new CoolingSystemBuilder()
            .WithDimensions(new CoolingCaseDimentions(12, 12))
            .WithName("AEROCOOL")
            .WithMaxTdp(123)
            .WithSupportedSockets(new[] { "123" })
            .Build();

        _coolingSystem.Add(coolingSystem);
    }

    public static CoolingSystemRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new CoolingSystemRepository();
            return _instance;
        }
    }

    public void Add(CoolingSystem newComponent)
    {
        _coolingSystem.Add(newComponent);
    }

    public CoolingSystem? Receive(string name)
    {
        foreach (CoolingSystem coolingSystem in _coolingSystem)
        {
            if (name == coolingSystem.Name) return coolingSystem;
        }

        return null;
    }
}