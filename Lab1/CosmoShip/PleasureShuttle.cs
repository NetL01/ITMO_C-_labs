using Itmo.ObjectOrientedProgramming.Lab1.Engine.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;

public class PleasureShuttle : SpaceShipBase
{
    public PleasureShuttle()
    {
        JumpEngine = null;
        Hull = new HullStrengthClass1();
        Deflector = null;
        ImpulseEngine = new ImpulseEngineClassC();
    }
}