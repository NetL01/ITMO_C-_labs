using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ComputerBuilder
{
    private string? _name;
    private ComputerCase? _computerCase;
    private CoolingSystem? _coolingSystem;
    private GraphicsCard? _graphicsCard;
    private Motherboard? _motherboard;
    private PowerSupply? _powerSupply;
    private Processor? _processor;
    private Collection<RAM?>? _ram = new();
    private WifiAdapter? _wifiAdapter;
    private Collection<IDataStorage?>? _dataStorages = new();

    public ComputerBuilder WithName(string? name)
    {
        _name = name;
        return this;
    }

    public ComputerBuilder WithComputerCase(ComputerCase? computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public ComputerBuilder WithCoolingSystem(CoolingSystem? coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public ComputerBuilder WithGraphicsCard(GraphicsCard? graphicsCard)
    {
        _graphicsCard = graphicsCard;
        return this;
    }

    public ComputerBuilder WithMotherboard(Motherboard? motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public ComputerBuilder WithPowerSupply(PowerSupply? powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public ComputerBuilder WithProcessor(Processor? processor)
    {
        _processor = processor;
        return this;
    }

    public ComputerBuilder AddRAM(RAM? ram)
    {
        _ram?.Add(ram);
        return this;
    }

    public ComputerBuilder AddDataStorage(IDataStorage? dataStorage)
    {
        _dataStorages?.Add(dataStorage);
        return this;
    }

    public ComputerBuilder WithWifiAdapter(WifiAdapter? wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public BuildResults Validate()
    {
        var errors = new StringBuilder(string.Empty);
        var warnings = new StringBuilder(string.Empty);

        if (_motherboard?.Socket != _processor?.Socket)
        {
            errors.Append("Error: Different sockets in Processor and motherboard.\n");
        }

        if (_ram != null)
        {
            foreach (RAM? ram in _ram)
            {
                if (_motherboard?.DdrStandard != ram?.DDRVersion)
                {
                    errors.Append("Error: Different ddr versions Motherboard and ram.\n");
                    break;
                }
            }
        }

        if (_graphicsCard is null && _processor?.IntegratedGraphics == false)
        {
            errors.Append("Error: Processor does not have a video core in absence of a video card.\n");
        }

        if (_computerCase != null && _graphicsCard != null && _graphicsCard.GraphicsCardSize.Height > _computerCase.Dimensions?.Height)
        {
            errors.Append("Error: Length of the video card exceeds the permissible.\n");
        }

        if (_graphicsCard != null && _graphicsCard.GraphicsCardSize.Weight > _computerCase?.Dimensions?.Width)
        {
            errors.Append("Error: Width of the video card exceeds the permissible.\n");
        }

        if (_motherboard?.RamSlots < _ram?.Count)
        {
            errors.Append("Error: Not enough ram slots.\n");
        }

        if (_motherboard?.SataPorts < _dataStorages?.Count)
        {
            errors.Append("Error: Not enough data storage slots.\n");
        }

        if (_motherboard?.Bios.SupportedProcessors is not null &&
            !_motherboard.Bios.SupportedProcessors.Contains(_processor?.Name))
        {
            errors.Append("Errors: Bios does not support cpu.\n");
        }

        if (_coolingSystem?.SupportedSockets is not null &&
            !_coolingSystem.SupportedSockets.Contains(_processor?.Socket))
        {
            errors.Append("Error: Unable to install cooling system.\n");
        }

        if (_processor?.Tdp > _coolingSystem?.MaxTDP)
        {
            warnings.Append("Warning: The heat dissipation of the cpu exceeds the maximum heat dissipation of the cooling system.\n" +
                            "Disclaimer of warranty.\n");
        }

        int ramPowerConsumption = 0;

        if (_ram is not null)
        {
            foreach (RAM? ram in _ram)
            {
                if (ram != null) ramPowerConsumption += ram.PowerConsumption;
            }
        }

        int dataStoragePowerConsumption = 0;

        if (_dataStorages != null)
        {
            foreach (IDataStorage? dataStorage in _dataStorages)
            {
                if (dataStorage != null) dataStoragePowerConsumption += dataStorage.PowerConsumption;
            }
        }

        if (_processor?.PowerConsumption +
            ramPowerConsumption +
            dataStoragePowerConsumption +
        _wifiAdapter?.PowerConsumption >
        _powerSupply?.Power)
        {
            warnings.Append(
                "Warning: The power consumption of the computer exceeds more energy for peak load moment.\n");
        }

        string errorsRes = errors.ToString();
        string warningsRes = warnings.ToString();

        if (!string.IsNullOrEmpty(errorsRes))
        {
            return new Failed(errorsRes);
        }

        if (!string.IsNullOrEmpty(warningsRes))
        {
            return new SuccessWithWarnings(warningsRes);
        }

        return new Success();
    }

    public Computer Build()
    {
        return new Computer(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _computerCase ?? throw new ArgumentNullException(nameof(_computerCase)),
            _coolingSystem ?? throw new ArgumentNullException(nameof(_coolingSystem)),
            _graphicsCard ?? throw new ArgumentNullException(nameof(_graphicsCard)),
            _motherboard ?? throw new ArgumentNullException(nameof(_motherboard)),
            _powerSupply ?? throw new ArgumentNullException(nameof(_powerSupply)),
            _processor ?? throw new ArgumentNullException(nameof(_processor)),
            _wifiAdapter ?? throw new ArgumentNullException(nameof(_wifiAdapter)),
            _dataStorages ?? throw new ArgumentNullException(nameof(_dataStorages)),
            _ram ?? throw new ArgumentNullException(nameof(_ram)));
    }
}