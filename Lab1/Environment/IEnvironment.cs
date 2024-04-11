using Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;
using Itmo.ObjectOrientedProgramming.Lab1.Result;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

public interface IEnvironment
{
    public TripResult? Trip(SpaceShipBase spaceShip);
}