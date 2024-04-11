using Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Obstacle;

public abstract class ObstacleBase
{
    protected ObstacleBase(double damage)
    {
        Damage = damage;
    }

    public double Damage { get; }

    public Events? GiveDamage(SpaceShipBase spaceShip)
    {
        if (spaceShip != null)
        {
            return spaceShip.TakeDamage(this);
        }

        return null;
    }
}