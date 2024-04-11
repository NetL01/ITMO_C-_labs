using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class SSDRepository : IRepository<SSD>
{
    private static SSDRepository? _instance;
    private Collection<SSD> _ssd;

    private SSDRepository()
    {
        _ssd = new();

        SSD ssd = new SSDBuilder()
            .WithCapacity(123)
            .WithName("BEST SDD")
            .WithPowerConsumption(10)
            .WithConnectionType("hex")
            .WithMaxSpeed(1000)
            .Build();

        _ssd.Add(ssd);
    }

    public static SSDRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new SSDRepository();
            return _instance;
        }
    }

    public void Add(SSD newComponent)
    {
        _ssd.Add(newComponent);
    }

    public SSD? Receive(string name)
    {
        foreach (SSD ssd in _ssd)
        {
            if (name == ssd.Name) return ssd;
        }

        return null;
    }
}