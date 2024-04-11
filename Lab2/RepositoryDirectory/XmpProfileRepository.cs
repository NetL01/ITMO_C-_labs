using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class XmpProfileRepository : IRepository<XmpProfile>
{
    private static XmpProfileRepository? _instance;
    private Collection<XmpProfile> _xmpProfile;

    private XmpProfileRepository()
    {
        _xmpProfile = new();

        XmpProfile xmpProfile = new XmpProfileBuilder()
            .WithName("XMP")
            .WithFrequency(123)
            .WithTimings("11-33-41")
            .WithVoltage(1233)
            .Build();

        _xmpProfile.Add(xmpProfile);
    }

    public static XmpProfileRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new XmpProfileRepository();
            return _instance;
        }
    }

    public void Add(XmpProfile newComponent)
    {
        _xmpProfile.Add(newComponent);
    }

    public XmpProfile? Receive(string name)
    {
        foreach (XmpProfile graphicsCard in _xmpProfile)
        {
            if (name == graphicsCard.Name) return graphicsCard;
        }

        return null;
    }
}