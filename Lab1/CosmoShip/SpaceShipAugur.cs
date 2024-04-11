using Itmo.ObjectOrientedProgramming.Lab1.CosmoShip;
using Itmo.ObjectOrientedProgramming.Lab1.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Impulse;
using Itmo.ObjectOrientedProgramming.Lab1.Engine.Jump;
using Itmo.ObjectOrientedProgramming.Lab1.HullStrength;

namespace Lab1SpaceInvaders.CosmoShip;

public class SpaceShipAugur : SpaceShipBase
{
    public SpaceShipAugur()
    {
        ImpulseEngine = new ImpulseEngineClassE();
        JumpEngine = new JumpEngineAlpha();
        Deflector = new DeflectorClass3();
        Hull = new HullStrengthClass3();
    }
}