namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;

public interface IJumpEngine
{
    double Distance { get; }
    double Speed { get; }
    double Consumption(double distance);
}