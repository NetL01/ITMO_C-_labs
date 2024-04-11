namespace Itmo.ObjectOrientedProgramming.Lab1.Guildy;

public class GravitoneMatereal : IFuelUsage
{
    public GravitoneMatereal(double fuelAmount)
    {
        FuelAmount = fuelAmount;
    }

    public double FuelAmount { get; }

    public double FuelCost() => 123;
}