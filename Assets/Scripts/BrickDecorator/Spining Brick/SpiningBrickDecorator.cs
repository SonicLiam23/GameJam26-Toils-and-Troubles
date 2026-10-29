using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SpiningBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public SpiningBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) { }
    public float rotation = 90f;
    float spinTimer = 10f;

    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();

        Core.transform.Rotate(0, 0, rotation);
        rotation *= -1f;
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
        Debug.Log("Spining Brick!");
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        spinTimer -= Time.deltaTime;

        if (spinTimer <= 0)
        {
            ActivateCurse();
            spinTimer = 30f;
        }
    }
}
