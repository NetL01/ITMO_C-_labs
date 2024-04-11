using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class MotherboardBuilder
{
    private string? _socket;
    private int _pciExpressLanes;
    private int _sataPorts;
    private string? _chipset;
    private int _ddrStandard;
    private int _ramSlots;
    private string? _formFactor;
    private BIOS? _bios;
    private string? _name;

    public MotherboardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public MotherboardBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public MotherboardBuilder WithPciExpressLanes(int pciExpressLanes)
    {
        _pciExpressLanes = pciExpressLanes;
        return this;
    }

    public MotherboardBuilder WithSataPorts(int sataPorts)
    {
        _sataPorts = sataPorts;
        return this;
    }

    public MotherboardBuilder WithChipset(string chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherboardBuilder WithDdrStandard(int ddrStandard)
    {
        _ddrStandard = ddrStandard;
        return this;
    }

    public MotherboardBuilder WithRamSlots(int ramSlots)
    {
        _ramSlots = ramSlots;
        return this;
    }

    public MotherboardBuilder WithFormFactor(string formFactor)
    {
        _formFactor = formFactor;
        return this;
    }

    public MotherboardBuilder WithBios(BIOS? bios)
    {
        _bios = bios;
        return this;
    }

    public Motherboard Build()
    {
        return new Motherboard(
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _pciExpressLanes,
            _sataPorts,
            _chipset ?? throw new ArgumentNullException(nameof(_chipset)),
            _ddrStandard,
            _ramSlots,
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _bios ?? throw new ArgumentNullException(nameof(_bios)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}