using UnityEngine;

public class ShrinkBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public ShrinkBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) { }
    float expandTimer = 10f;

    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().
    bool activated = false;

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
        activated = true;

        GameManager.Instance.UnlockAll();
        Core.transform.localScale *= 0.5f;

    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
        Debug.Log("Shrinking Brick!");
        Core.spriteRenderer.sprite = GameManager.Instance.Shrinking;
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        expandTimer -= Time.deltaTime;

        if (!activated && expandTimer <= 0)
        {
            ActivateCurse();
        }
    }
}
