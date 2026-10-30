using Unity.VisualScripting;
using UnityEngine;

public class IceBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public IceBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) { }
    float expandTimer = 10f;
    float scale = 1f;


    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().
    bool activated = false;

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
        Core.spriteRenderer.sprite = GameManager.Instance.Ice;
        Core.rb.sharedMaterial = GameManager.Instance.IceMaterial;
        Debug.Log("Ice Brick!");
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();
    }
}
