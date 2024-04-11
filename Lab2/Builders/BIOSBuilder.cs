using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Builders;

public class BIOSBuilder
{
    private string? _type;
    private string? _version;
    private IReadOnlyList<string>? _supportedProcessors;
    private string? _name;

    public BIOSBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public BIOSBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public BIOSBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public BIOSBuilder WithSupportedProcessors(IReadOnlyList<string>? processors)
    {
        _supportedProcessors = processors;
        return this;
    }

    public BIOS Build()
    {
        return new BIOS(
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _supportedProcessors ?? throw new ArgumentNullException(nameof(_supportedProcessors)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}