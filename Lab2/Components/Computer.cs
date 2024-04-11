using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Computer
{
    public Computer(
        string name,
        ComputerCase? computerCase,
        CoolingSystem? coolingSystem,
        GraphicsCard? graphicsCard,
        Motherboard? motherboard,
        PowerSupply? powerSupply,
        Processor? processor,
        WifiAdapter? wifiAdapter,
        Collection<IDataStorage?> dataStorages,
        Collection<RAM?> rams)
    {
        Name = name;
        ComputerCase = computerCase;
        CoolingSystem = coolingSystem;
        GraphicsCard = graphicsCard;
        Motherboard = motherboard;
        PowerSupply = powerSupply;
        Processor = processor;
        WifiAdapter = wifiAdapter;
        Rams = rams;
        DataStorages = dataStorages;
    }

    public string Name { get; }
    public ComputerCase? ComputerCase { get; }
    public CoolingSystem? CoolingSystem { get; }
    public GraphicsCard? GraphicsCard { get; }
    public Motherboard? Motherboard { get; }
    public PowerSupply? PowerSupply { get; }
    public Processor? Processor { get; }
    public Collection<RAM?> Rams { get; init; }
    public Collection<IDataStorage?> DataStorages { get; init; }
    public WifiAdapter? WifiAdapter { get; }

    public ComputerBuilder? Direct(ComputerBuilder? computerBuilder)
    {
        if (computerBuilder is not null)
        {
            computerBuilder
                .WithName(Name)
                .WithMotherboard(Motherboard)
                .WithProcessor(Processor)
                .WithComputerCase(ComputerCase)
                .WithCoolingSystem(CoolingSystem)
                .WithGraphicsCard(GraphicsCard)
                .WithPowerSupply(PowerSupply)
                .WithWifiAdapter(WifiAdapter)
                .Build();

            foreach (RAM? ram in Rams)
            {
                computerBuilder.AddRAM(ram);
            }

            foreach (IDataStorage? dataStorage in DataStorages)
            {
                computerBuilder.AddDataStorage(dataStorage);
            }
        }

        return computerBuilder;
    }
}