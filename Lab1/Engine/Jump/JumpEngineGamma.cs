namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;

public class JumpEngineGamma : IJumpEngine
{
    public double Distance { get; }
    public double Speed { get; } = 20;

    public double Consumption(double distance)
    {
        return double.Pow(distance, 2);
    }
}