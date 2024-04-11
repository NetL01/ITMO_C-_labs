namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public interface IDataStorage
{
    public string ConnectionType { get; init; }
    public string Name { get; init; }
    public int PowerConsumption { get; init; }
}