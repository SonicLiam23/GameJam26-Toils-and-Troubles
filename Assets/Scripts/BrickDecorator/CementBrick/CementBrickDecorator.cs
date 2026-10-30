using UnityEngine;

public class CementBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public CementBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) { }

    public bool activated = false;

    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().

    override public void ActivateCurse()
    {
        Debug.Log("Activated cement");
        decoratedBrick.ActivateCurse();
        activated = true;
    }

    override public void ApplyCurse()
    {
        
        decoratedBrick.ApplyCurse();
        Debug.Log("Cement Block");


    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        if (!activated && Core.fsm.CompareCurrentState(typeof(LockedState)))
        {
            ActivateCurse();
        }

        if (activated) Core.fsm.ChangeState(typeof(LockedState));
    }
}

