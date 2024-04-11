namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;

public class JumpEngineOmega : IJumpEngine
{
    public double Distance { get; }
    public double Speed { get; } = 25;

    public double Consumption(double distance)
    {
        return distance * double.Log(distance);
    }
}