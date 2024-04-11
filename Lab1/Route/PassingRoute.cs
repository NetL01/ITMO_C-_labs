using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Route;

public class PassingRoute
{
    private IReadOnlyList<IEnvironment> _environmentCollection;

    public PassingRoute(IReadOnlyList<IEnvironment> environmentCollection)
         {
             _environmentCollection = environmentCollection;
         }

    public TripResult? Trip(SpaceShipBase spaceShip)
    {
        double time = 0;
        double fuel = 0;

        foreach (IEnvironment environment in _environmentCollection)
        {
            TripResult? tripResult = environment.Trip(spaceShip);

            if (tripResult is Success successResult)
            {
                time += successResult.Time;
                fuel += successResult.Fuel;
            }

            return tripResult;
        }

        return new Success(time, fuel);
    }
}