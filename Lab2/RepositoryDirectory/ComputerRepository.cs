using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Dimentions;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class ComputerRepository : IRepository<Computer>
{
    private static ComputerRepository? _instance;
    private Collection<Computer> _computer;

    private ComputerRepository()
    {
        _computer = new();
        var builder = new ComputerBuilder();

        _computer.Add(builder
            .WithName("Computer")
            .AddDataStorage(HDDRepository.Instance.Receive("TOP HDD"))
            .WithMotherboard(MotherboardRepository.Instance.Receive("b550 twin turbo bmw m5 cs asphalt 8"))
            .WithProcessor(ProcessorRepository.Instance.Receive("AMD Super"))
            .WithComputerCase(ComputerCaseRepository.Instance.Receive("STEELSERIES"))
            .WithCoolingSystem(CoolingSystemRepository.Instance.Receive("AEROCOOL"))
            .WithGraphicsCard(GraphicCardRepository.Instance.Receive("4090 GameRock"))
            .WithPowerSupply(PowerSupplyRepository.Instance.Receive("KSAS"))
            .WithWifiAdapter(WifiAdapterRepository.Instance.Receive("best wifi"))
            .AddRAM(RAMRepository.Instance.Receive("TOP RAM"))
            .Build());

        _computer.Add(builder
            .WithName("Computer2")
            .AddDataStorage(HDDRepository.Instance.Receive("TOP HDD"))
            .WithMotherboard(MotherboardRepository.Instance.Receive("b550 twin turbo bmw m5 cs asphalt 8"))
            .WithProcessor(ProcessorRepository.Instance.Receive("AMD Super"))
            .WithComputerCase(ComputerCaseRepository.Instance.Receive("STEELSERIES"))
            .WithCoolingSystem(CoolingSystemRepository.Instance.Receive("AEROCOOL"))
            .WithGraphicsCard(GraphicCardRepository.Instance.Receive("4090 GameRock"))
            .WithPowerSupply(new PowerSupply(1, "PS"))
            .WithWifiAdapter(WifiAdapterRepository.Instance.Receive("best wifi"))
            .AddRAM(RAMRepository.Instance.Receive("TOP RAM"))
            .Build());

        _computer.Add(builder
            .WithName("Computer3")
            .AddDataStorage(HDDRepository.Instance.Receive("TOP HDD"))
            .WithMotherboard(MotherboardRepository.Instance.Receive("b550 twin turbo bmw m5 cs asphalt 8"))
            .WithProcessor(ProcessorRepository.Instance.Receive("AMD Super"))
            .WithComputerCase(ComputerCaseRepository.Instance.Receive("STEELSERIES"))
            .WithCoolingSystem(new CoolingSystemBuilder()
                .WithDimensions(new CoolingCaseDimentions(12, 12))
                .WithName("AEROCOOL")
                .WithMaxTdp(99)
                .WithSupportedSockets(new[] { "123" })
                .Build())
            .WithGraphicsCard(GraphicCardRepository.Instance.Receive("4090 GameRock"))
            .WithPowerSupply(new PowerSupply(1, "PS"))
            .WithWifiAdapter(WifiAdapterRepository.Instance.Receive("best wifi"))
            .AddRAM(RAMRepository.Instance.Receive("TOP RAM"))
            .Build());

        _computer.Add(builder
            .WithName("Computer4")
            .AddDataStorage(HDDRepository.Instance.Receive("TOP HDD"))
            .WithMotherboard(MotherboardRepository.Instance.Receive("b550 twin turbo bmw m5 cs asphalt 8"))
            .WithProcessor(ProcessorRepository.Instance.Receive("AMD Super"))
            .WithComputerCase(new ComputerCaseBuilder()
                .WithDimensions(new CaseDimentions(1, 1))
                .WithName("Case")
                .WithMaxVideoCardSize(new CaseDimentions(150, 150))
                .WithSupportedMotherboardFormFactors(140)
                .Build())
            .WithCoolingSystem(CoolingSystemRepository.Instance.Receive("AEROCOOL"))
            .WithGraphicsCard(new GraphicsCardBuilder()
                .WithName("VideoCard")
                .WithChipFrequency(3600)
                .WithPowerConsumption(300)
                .WithGraphicsCardSize(new GraphicsCardDimentions(100, 100))
                .WithPciExpressVersion(12)
                .WithVideoMemorySize(12123123)
                .Build())
            .WithPowerSupply(PowerSupplyRepository.Instance.Receive("KSAS"))
            .WithWifiAdapter(WifiAdapterRepository.Instance.Receive("best wifi"))
            .AddRAM(RAMRepository.Instance.Receive("TOP RAM"))
            .Build());
    }

    public static ComputerRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new ComputerRepository();
            return _instance;
        }
    }

    public void Add(Computer newComponent)
    {
        _computer.Add(newComponent);
    }

    public Computer? Receive(string name)
    {
        foreach (Computer computer in _computer)
        {
            if (name == computer.Name) return computer;
        }

        return null;
    }
}
