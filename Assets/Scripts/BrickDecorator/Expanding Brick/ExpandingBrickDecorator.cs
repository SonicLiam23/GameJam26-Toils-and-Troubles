using System.Drawing;
using UnityEditor.Rendering;
using UnityEngine;

public class ExpandingBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public ExpandingBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) { }
    float expandTimer = 10f;


    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();

        if (Core.transform.localScale.x < 2)
        {
            Core.transform.localScale = new Vector3(Core.transform.localScale.x + 0.001f, Core.transform.localScale.y + 0.001f, 0);
        }
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
        Debug.Log("Expanding Brick!");
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        expandTimer -= Time.deltaTime;

        if (expandTimer <= 0)
        {
            ActivateCurse();
            expandTimer = 0.1f;
        }
    }
}
