using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public class NormalSpace : IEnvironment
{
    private double _distance;
    private IReadOnlyList<ObstacleBase> _obstaclesCollection;

    public NormalSpace(double distance, IReadOnlyList<ObstacleBase> obstaclesCollection)
    {
        _obstaclesCollection = obstaclesCollection;
        _distance = distance;
    }

    public TripResult? Trip(SpaceShipBase spaceShip)
    {
        foreach (ObstacleBase obstacle in _obstaclesCollection)
        {
            if (obstacle.GiveDamage(spaceShip) is Events.SpaceShipDestroyed)
            {
                return new Fail();
            }
        }

        if (spaceShip != null && spaceShip.ImpulseEngine != null)
        {
            double time = _distance / spaceShip.ImpulseEngine.Speed;
            double fuel = time * spaceShip.ImpulseEngine.Consumption;
            return new Success(time, fuel);
        }

        return null;
    }
}