using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class IncreasedDensityNebulae : IEnvironment
{
    private double _distance;
    private IReadOnlyList<ObstacleBase> _obstaclesCollection;

    public IncreasedDensityNebulae(
        double distance,
        IReadOnlyList<ObstacleBase> obstaclesCollection)
    {
        _obstaclesCollection = obstaclesCollection;
        _distance = distance;
    }

    public TripResult? Trip(SpaceShipBase spaceShip)
    {
        if (spaceShip != null && (spaceShip.JumpEngine is null || spaceShip.JumpEngine.Distance < _distance))
        {
            return new Fail();
        }

        if (spaceShip?.Deflector?.IsPhotonDeflector != true)
        {
            return new Fail();
        }

        foreach (ObstacleBase obstacle in _obstaclesCollection)
        {
            if (spaceShip != null && obstacle.GiveDamage(spaceShip) is Events.SpaceShipDestroyed)
            {
                return new Fail();
            }
        }

        if (spaceShip != null && spaceShip.JumpEngine != null)
        {
            double time = _distance / spaceShip.JumpEngine.Speed;
            double fuel = time * spaceShip.JumpEngine.Consumption(_distance);
            return new Success(time, fuel);
        }

        return null;
    }
}