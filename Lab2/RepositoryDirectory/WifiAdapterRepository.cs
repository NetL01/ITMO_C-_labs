using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class WifiAdapterRepository : IRepository<WifiAdapter>
{
    private static WifiAdapterRepository? _instance;
    private Collection<WifiAdapter> _wifiAdapter;

    private WifiAdapterRepository()
    {
        _wifiAdapter = new();

        WifiAdapter wifiAdapter = new WifiAdapterBuilder()
            .WithPowerConsumption(10)
            .WithName("best wifi")
            .WithBluetooth(true)
            .WithPcieVersion("123")
            .WithWifiStandardVersion("always stable best")
            .Build();

        _wifiAdapter.Add(wifiAdapter);
    }

    public static WifiAdapterRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new WifiAdapterRepository();
            return _instance;
        }
    }

    public void Add(WifiAdapter newComponent)
    {
        _wifiAdapter.Add(newComponent);
    }

    public WifiAdapter? Receive(string name)
    {
        foreach (WifiAdapter wifiAdapter in _wifiAdapter)
        {
            if (name == wifiAdapter.Name) return wifiAdapter;
        }

        return null;
    }
}