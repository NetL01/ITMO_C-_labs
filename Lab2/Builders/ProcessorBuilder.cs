using System;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class ProcessorBuilder
{
    private int _frequency;
    private int _cores;
    private string? _socket;
    private bool _integratedGraphics;
    private int _supportedMemoryFrequencies;
    private int _tdp;
    private int _powerConsumption;
    private string? _name;

    public ProcessorBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProcessorBuilder WithFrequency(int frequency)
    {
        _frequency = frequency;
        return this;
    }

    public ProcessorBuilder WithCores(int cores)
    {
        _cores = cores;
        return this;
    }

    public ProcessorBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ProcessorBuilder WithIntegratedGraphics(bool integratedGraphics)
    {
        _integratedGraphics = integratedGraphics;
        return this;
    }

    public ProcessorBuilder WithSupportedMemoryFrequencies(int supportedMemoryFrequencies)
    {
        _supportedMemoryFrequencies = supportedMemoryFrequencies;
        return this;
    }

    public ProcessorBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ProcessorBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Processor Build()
    {
        return new Processor(
            _cores,
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _integratedGraphics,
            _tdp,
            _powerConsumption,
            _frequency,
            _supportedMemoryFrequencies,
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}