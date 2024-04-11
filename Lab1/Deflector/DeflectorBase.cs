using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Deflector;

public abstract class DeflectorBase
{
    private double _hp;
    private double _damageCoef;

    protected DeflectorBase(double hp, double damageCoef)
    {
        _hp = hp;
        _damageCoef = damageCoef;
    }

    public bool IsPhotonDeflector { get; set; }
    public Events? TakeDamage(ObstacleBase obstacle)
    {
        if (obstacle != null)
        {
            _hp -= obstacle.Damage * _damageCoef;
        }

        if (_hp < 0)
        {
            return Events.DeflectorDestroyed;
        }

        return Events.DeflectorSaved;
    }

    public bool IsAlive()
    {
        return _hp >= 0;
    }
}