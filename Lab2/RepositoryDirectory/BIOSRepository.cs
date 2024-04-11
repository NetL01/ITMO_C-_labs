using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class BIOSRepository : IRepository<BIOS>
{
    private static BIOSRepository? _instance;
    private Collection<BIOS> _bios;

    private BIOSRepository()
    {
        _bios = new();

        BIOS biosv2 = new BIOSBuilder()
            .WithType("TOPBIOS")
            .WithVersion("TOPVERSION")
            .WithSupportedProcessors(new List<string> { "Intel Foo", "AMD Super" })
            .WithName("NameValue")
            .Build();

        _bios.Add(biosv2);
    }

    public static BIOSRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new BIOSRepository();
            return _instance;
        }
    }

    public void Add(BIOS newComponent)
    {
        _bios.Add(newComponent);
    }

    public BIOS? Receive(string name)
    {
        foreach (BIOS bios in _bios)
        {
            if (name == bios.Name) return bios;
        }

        return null;
    }
}