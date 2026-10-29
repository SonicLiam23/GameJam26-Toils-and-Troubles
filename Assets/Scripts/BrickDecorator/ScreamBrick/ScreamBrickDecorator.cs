using UnityEngine;

public class ScreamBrickDecorator : BrickDecorator
{
    public ScreamBrickDecorator(Brick decoratedBrick) : base(decoratedBrick)
    {}

    float timer = 5f;
    bool activated = false;

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
        activated = true;

        Core.gameObject.layer = LayerMask.NameToLayer("Default");
        Core.rb.excludeLayers = ~(1 << LayerMask.NameToLayer("Floor"));

        Core.Colour = Color.yellow;

        Core.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;


        GameManager.Instance.UnlockAll();
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();

        Debug.Log("WalkBrick!");

    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        timer -= Time.deltaTime;

        if (!activated && timer <= 0f)
        {
            ActivateCurse();
        }

        if (activated)
        {
            Core.rb.linearVelocityX = -2f;
        }
    }
}
