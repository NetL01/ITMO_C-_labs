using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class RAMRepository : IRepository<RAM>
{
    private static RAMRepository? _instance;
    private Collection<RAM> _ram;

    private RAMRepository()
    {
        _ram = new();
        RAM ram = new RAMBuilder()
            .WithName("TOP RAM")
            .WithFormFactor("best")
            .WithPowerConsumption(50)
            .WithDDRVersion(123)
            .WithAvailableMemory(1000)
            .WithAvailableXMPProfiles(new[] { "cool" })
            .WithSupportedJEDEC(15)
            .Build();

        _ram.Add(ram);
    }

    public static RAMRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new RAMRepository();
            return _instance;
        }
    }

    public void Add(RAM newComponent)
    {
        _ram.Add(newComponent);
    }

    public RAM? Receive(string name)
    {
        foreach (RAM ram in _ram)
        {
            if (name == ram.Name) return ram;
        }

        return null;
    }
}