using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class HDD : IDataStorage
{
    public HDD(int spindleSpeed, int capacity, int powerConsumption, string name)
    {
        SpindleSpeed = spindleSpeed;
        Capacity = capacity;
        PowerConsumption = powerConsumption;
        Name = name;
    }

    public string ConnectionType { get; init; } = "PciE";
    public int Capacity { get; }
    public int PowerConsumption { get; init; }
    public string Name { get; init; }
    public int SpindleSpeed { get; }

    public HDDBuilder? Direct(HDDBuilder hddBuilder)
    {
        hddBuilder?
            .WithName(Name)
            .WithPowerConsumption(PowerConsumption)
            .WithCapacity(Capacity)
            .WithSpindleSpeed(SpindleSpeed);

        return hddBuilder;
    }
}