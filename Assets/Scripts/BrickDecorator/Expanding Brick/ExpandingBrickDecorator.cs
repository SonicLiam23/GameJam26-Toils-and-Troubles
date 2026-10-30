using UnityEngine;

public class ExpandingBrickDecorator : BrickDecorator
{
    // Must have line, replace ExampleBrickDecorator with your class name.
    public ExpandingBrickDecorator(Brick decoratedBrick) : base(decoratedBrick) { }
    float expandTimer = 10f;
    float scale = 1f;


    // CURSE BEHAVIOUR, each of these is optional, but they MUST run decoratedBrick.FUNCTION().
    bool activated = false;

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
        activated = true;

        GameManager.Instance.UnlockAll();
        Core.transform.localScale *= 1.5f;

    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
        Debug.Log("Expanding Brick!");
        Core.spriteRenderer.sprite = GameManager.Instance.Expanding;
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
