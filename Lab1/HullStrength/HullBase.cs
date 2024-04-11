using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

public abstract class HullBase
{
    private double _hp;
    private double _damageCoef;

    protected HullBase(double damageCoef, double hp)
    {
        _hp = hp;
        _damageCoef = damageCoef;
    }

    public Events? TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle != null)
        {
            _hp -= obstacle.Damage * _damageCoef;
        }

        if (_hp < 0)
        {
            return Events.HullDestroyed;
        }

        return Events.HullSaved;
    }
}