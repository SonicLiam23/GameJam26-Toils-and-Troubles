using UnityEngine;

public class TeleportBrickDecorator : BrickDecorator
{
    public TeleportBrickDecorator(Brick decoratedBrick) : base(decoratedBrick)
    {}

    float teleportTimer = 10f;


    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();

        GameManager.Instance.UnlockAll();
        // teleport it somewhere above itself with a slight offset.
        Core.rb.linearVelocity = Vector3.zero;

        Vector2 pos = Core.transform.position;
        pos.y += 4;
        pos.x += Random.Range(-2f, 2f);

        Core.transform.position = pos;
        
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();

        Debug.Log("Teleport Brick!");
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        teleportTimer -= Time.deltaTime;

        if (teleportTimer <= 0)
        {
            ActivateCurse();
            teleportTimer = 30f;
        }
    }
}
