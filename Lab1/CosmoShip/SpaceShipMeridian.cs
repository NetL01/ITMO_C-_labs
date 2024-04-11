using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;

public class SpaceShipMeridian : SpaceShipBase
{
    public SpaceShipMeridian()
    {
        ImpulseEngine = new ImpulseEngineClassE();
        JumpEngine = null;
        Deflector = new DeflectorClass2();
        Hull = new HullStrengthClass2();
    }
}