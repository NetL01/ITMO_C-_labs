using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class WifiAdapter
{
    public WifiAdapter(string wifiStandardVersion, bool hasBluetooth, string pcieVersion, decimal powerConsumption, string name)
    {
        WifiStandardVersion = wifiStandardVersion;
        HasBluetooth = hasBluetooth;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public string WifiStandardVersion { get; }
    public bool HasBluetooth { get; }
    public string PcieVersion { get; }
    public decimal PowerConsumption { get; }
    public string Name { get; }

    public WifiAdapterBuilder? Direct(WifiAdapterBuilder wifiAdapterBuilder)
    {
        wifiAdapterBuilder?
            .WithName(Name)
            .WithPowerConsumption(PowerConsumption)
            .WithBluetooth(HasBluetooth)
            .WithPcieVersion(PcieVersion)
            .WithWifiStandardVersion(WifiStandardVersion);

        return wifiAdapterBuilder;
    }
}