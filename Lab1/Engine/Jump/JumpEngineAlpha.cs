namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;

public class JumpEngineAlpha : IJumpEngine
{
    public double Distance { get; }
    public double Speed { get; } = 15;

    public double Consumption(double distance)
    {
        return distance;
    }
}