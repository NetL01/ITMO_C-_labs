using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;

public abstract class SpaceShipBase
{
    public IImpulseEngine? ImpulseEngine { get; protected set; }
    public IJumpEngine? JumpEngine { get; protected set; }
    public HullBase? Hull { get; protected set; }
    public DeflectorBase? Deflector { get; protected set; }

    public Events? TakeDamage(ObstacleBase obstacle)
    {
        if (Deflector != null && Deflector.IsAlive())
        {
            return Deflector.TakeDamage(obstacle);
        }

        return Hull?.TakeDamage(obstacle);
    }
}