using Itmo.ObjectOrientedProgramming.Lab2.Builders;
namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class Motherboard
{
    public Motherboard(
        string socket,
        int pciExpressLanes,
        int sataPorts,
        string chipset,
        int ddrStandard,
        int ramSlots,
        string formFactor,
        BIOS bios,
        string name)
    {
        Socket = socket;
        PciExpressLanes = pciExpressLanes;
        SataPorts = sataPorts;
        Chipset = chipset;
        DdrStandard = ddrStandard;
        RamSlots = ramSlots;
        FormFactor = formFactor;
        Bios = bios;
        Name = name;
    }

    public string Socket { get; }
    public int PciExpressLanes { get; }
    public int SataPorts { get; }
    public string Chipset { get; }
    public int DdrStandard { get; }
    public int RamSlots { get; }
    public string FormFactor { get; }
    public BIOS Bios { get; }
    public string Name { get; }

    public MotherboardBuilder? Direct(MotherboardBuilder motherboardBuilder)
    {
        motherboardBuilder?
            .WithName(Name)
            .WithChipset(Chipset)
            .WithSocket(Socket)
            .WithBios(Bios)
            .WithDdrStandard(DdrStandard)
            .WithFormFactor(FormFactor)
            .WithRamSlots(RamSlots)
            .WithSataPorts(SataPorts)
            .WithPciExpressLanes(PciExpressLanes);

        return motherboardBuilder;
    }
}