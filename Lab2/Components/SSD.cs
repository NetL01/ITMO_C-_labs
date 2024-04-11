using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class SSD : IDataStorage
{
    public SSD(int capacity, int maxSpeed, int powerConsumption, string name)
    {
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public string ConnectionType { get; init; } = "Sata";
    public int Capacity { get; init; }
    public int MaxSpeed { get; init; }
    public int PowerConsumption { get; init; }
    public string Name { get; init; }

    public SSDBuilder? Direct(SSDBuilder ssdBuilder)
    {
        ssdBuilder?
            .WithName(Name)
            .WithCapacity(Capacity)
            .WithPowerConsumption(PowerConsumption)
            .WithConnectionType(ConnectionType)
            .WithMaxSpeed(MaxSpeed);

        return ssdBuilder;
    }
}