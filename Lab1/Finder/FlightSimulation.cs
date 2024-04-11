using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Result;
using Itmo.ObjectOrientedProgramming.Lab1.Route;

namespace Itmo.ObjectOrientedProgramming.Lab1.Finder;

public class FlightSimulation
{
    private readonly IReadOnlyList<SpaceShipBase> _ships;
    private readonly IReadOnlyList<IEnvironment> _environments;

    public FlightSimulation(IReadOnlyList<SpaceShipBase> ships, IReadOnlyList<IEnvironment> environments)
    {
        _ships = ships;
        _environments = environments;
    }

    public SpaceShipBase? FindBest()
    {
        Dictionary<TripResult, SpaceShipBase> results = new();

        foreach (SpaceShipBase ship in _ships)
        {
            TripResult? tmpResult = new PassingRoute(_environments).Trip(ship);

            if (tmpResult != null)
            {
                results[tmpResult] = ship;
            }
        }

        SpaceShipBase? ans = null;
        double min = double.MaxValue;

        foreach (KeyValuePair<TripResult, SpaceShipBase> it in results)
        {
            if (it.Key is Success success && success.Fuel + success.Time < min)
            {
                ans = it.Value;
            }
        }

        return ans;
    }
}