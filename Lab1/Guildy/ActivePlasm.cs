namespace Itmo.ObjectOrientedProgramming.Lab1.Guildy;

public class ActivePlasm : IFuelUsage
{
    public ActivePlasm(double fuelAmount)
    {
        FuelAmount = fuelAmount;
    }

    public double FuelAmount { get; }

    public double FuelCost() => 3213;
}