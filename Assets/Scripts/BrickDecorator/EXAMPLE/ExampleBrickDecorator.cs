using UnityEngine;

public class ExampleBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public ExampleBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) {}



    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();
    }
}
