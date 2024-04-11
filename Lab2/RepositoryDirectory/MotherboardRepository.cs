using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class MotherboardRepository : IRepository<Motherboard>
{
    private static MotherboardRepository? _instance;
    private Collection<Motherboard> _motherboard;

    private MotherboardRepository()
    {
        _motherboard = new();

        Motherboard motherboard = new MotherboardBuilder()
            .WithName("b550 twin turbo bmw m5 cs asphalt 8")
            .WithChipset("132")
            .WithSocket("123")
            .WithBios(BIOSRepository.Instance.Receive("NameValue"))
            .WithDdrStandard(123)
            .WithFormFactor("best")
            .WithRamSlots(5)
            .WithSataPorts(5)
            .WithPciExpressLanes(1)
            .Build();

        _motherboard.Add(motherboard);
    }

    public static MotherboardRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new MotherboardRepository();
            return _instance;
        }
    }

    public void Add(Motherboard newComponent)
    {
        _motherboard.Add(newComponent);
    }

    public Motherboard? Receive(string name)
    {
        foreach (Motherboard motherboard in _motherboard)
        {
            if (name == motherboard.Name) return motherboard;
        }

        return null;
    }
}