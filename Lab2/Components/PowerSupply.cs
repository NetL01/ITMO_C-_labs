using Itmo.ObjectOrientedProgramming.Lab2.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Components;

public class PowerSupply
{
    public PowerSupply(decimal power, string name)
    {
        Power = power;
        Name = name;
    }

    public decimal Power { get; }
    public string Name { get; }

    public PowerSupplyBuilder? Direct(PowerSupplyBuilder powerSupplyBuilder)
    {
        powerSupplyBuilder?
            .WithName(Name)
            .WithPower(Power);

        return powerSupplyBuilder;
    }
}