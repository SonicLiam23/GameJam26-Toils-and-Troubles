using UnityEngine;

public class GlowingBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public GlowingBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) { }

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
        Debug.Log("Glowing Brick!");
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();
    }
}
