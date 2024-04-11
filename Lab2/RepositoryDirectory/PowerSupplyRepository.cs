using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class PowerSupplyRepository : IRepository<PowerSupply>
{
    private static PowerSupplyRepository? _instance;
    private Collection<PowerSupply> _powerSupply;

    private PowerSupplyRepository()
    {
        _powerSupply = new();
        PowerSupply powerSupply = new PowerSupplyBuilder()
            .WithName("KSAS")
            .WithPower(1000000000)
            .Build();

        _powerSupply.Add(powerSupply);
    }

    public static PowerSupplyRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new PowerSupplyRepository();
            return _instance;
        }
    }

    public void Add(PowerSupply newComponent)
    {
        _powerSupply.Add(newComponent);
    }

    public PowerSupply? Receive(string name)
    {
        foreach (PowerSupply powerSupply in _powerSupply)
        {
            if (name == powerSupply.Name) return powerSupply;
        }

        return null;
    }
}