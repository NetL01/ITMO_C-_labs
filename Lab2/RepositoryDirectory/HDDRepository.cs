using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class HDDRepository : IRepository<HDD>
{
    private static HDDRepository? _instance;
    private Collection<HDD> _hdd;

    private HDDRepository()
    {
        _hdd = new();

        HDD hdd = new HDDBuilder()
            .WithName("TOP HDD")
            .WithPowerConsumption(50)
            .WithCapacity(10)
            .WithSpindleSpeed(10000)
            .Build();

        _hdd.Add(hdd);
    }

    public static HDDRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new HDDRepository();
            return _instance;
        }
    }

    public void Add(HDD newComponent)
    {
        _hdd.Add(newComponent);
    }

    public HDD? Receive(string name)
    {
        foreach (HDD hdd in _hdd)
        {
            if (name == hdd.Name) return hdd;
        }

        return null;
    }
}