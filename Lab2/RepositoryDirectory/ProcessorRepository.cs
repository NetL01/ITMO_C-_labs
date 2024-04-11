using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public class ProcessorRepository : IRepository<Processor>
{
    private static ProcessorRepository? _instance;
    private Collection<Processor> _processor;

    private ProcessorRepository()
    {
        _processor = new();
        Processor processor = new ProcessorBuilder()
            .WithName("AMD Super")
            .WithSocket("123")
            .WithPowerConsumption(50)
            .WithCores(5)
            .WithTdp(100)
            .WithFrequency(1000)
            .WithIntegratedGraphics(true)
            .WithSupportedMemoryFrequencies(123132)
            .Build();

        _processor.Add(processor);
    }

    public static ProcessorRepository Instance
    {
        get
        {
            if (_instance is null) _instance = new ProcessorRepository();
            return _instance;
        }
    }

    public void Add(Processor newComponent)
    {
        _processor.Add(newComponent);
    }

    public Processor? Receive(string name)
    {
        foreach (Processor processor in _processor)
        {
            if (name == processor.Name) return processor;
        }

        return null;
    }
}