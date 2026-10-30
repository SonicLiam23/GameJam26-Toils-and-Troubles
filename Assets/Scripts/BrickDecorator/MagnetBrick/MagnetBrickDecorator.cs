using UnityEngine;

public class MagnetBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public MagnetBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) {}



    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
        Core.spriteRenderer.sprite = GameManager.Instance.Magnet;
        Debug.Log("Magnet Brick!");
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();
    }
}
