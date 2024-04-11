using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;

public class SpaceShipStella : SpaceShipBase
{
    public SpaceShipStella()
    {
        ImpulseEngine = new ImpulseEngineClassC();
        JumpEngine = new JumpEngineOmega();
        Deflector = new DeflectorClass1();
        Hull = new HullStrengthClass1();
    }
}