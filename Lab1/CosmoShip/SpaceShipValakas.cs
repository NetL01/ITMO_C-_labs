using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;

public class SpaceShipValakas : SpaceShipBase
{
    public SpaceShipValakas()
    {
        ImpulseEngine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineGamma();
        Deflector = new DeflectorClass1();
        Hull = new HullStrengthClass2();
    }
}