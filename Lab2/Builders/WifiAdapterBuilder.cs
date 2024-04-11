using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class WifiAdapterBuilder
{
    private string? _wifiStandardVersion;
    private bool? _hasBluetooth;
    private string? _pcieVersion;
    private decimal _powerConsumption;
    private string? _name;

    public WifiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WifiAdapterBuilder WithWifiStandardVersion(string wifiStandardVersion)
    {
        _wifiStandardVersion = wifiStandardVersion;
        return this;
    }

    public WifiAdapterBuilder WithBluetooth(bool hasBluetooth)
    {
        _hasBluetooth = hasBluetooth;
        return this;
    }

    public WifiAdapterBuilder WithPcieVersion(string pcieVersion)
    {
        _pcieVersion = pcieVersion;
        return this;
    }

    public WifiAdapterBuilder WithPowerConsumption(decimal powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WifiAdapter Build()
    {
        return new WifiAdapter(
            _wifiStandardVersion ?? throw new ArgumentNullException(nameof(_wifiStandardVersion)),
            _hasBluetooth ?? throw new ArgumentNullException(nameof(_hasBluetooth)),
            _pcieVersion ?? throw new ArgumentNullException(nameof(_pcieVersion)),
            _powerConsumption,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}