using UnityEngine;

public class TeleportBrickDecorator : BrickDecorator
{
    public TeleportBrickDecorator(Brick decoratedBrick) : base(decoratedBrick)
    {}

    float teleportTimer = 3f;
    bool activated = false;

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();

        GameManager.Instance.UnlockAll();
        // teleport it somewhere above itself with a slight offset.
        Core.rb.linearVelocity = Vector3.zero;

        Vector2 pos = Core.transform.position;
        pos.y += 4;
        pos.x += Random.Range(-2f, 2f);

        Color newColor = Core.Colour;
        newColor.a = 1f;
        Core.Colour = newColor;

        Core.transform.position = pos;
        activated = true;

        Core.spriteRenderer.sprite = GameManager.Instance.NormalBrick;
        
    }

    override public void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();

        Core.spriteRenderer.sprite = GameManager.Instance.Spiral;

        Debug.Log("Teleport Brick!");
    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        if (!Core.fsm.CompareCurrentState(typeof(DraggingState)))
        {
            teleportTimer -= Time.deltaTime;
            if (!activated)
            {
                Color newColor = Core.Colour;
                
                newColor.a = Mathf.Lerp(0f, 1f, teleportTimer / 3f);
                Core.Colour = newColor;

                if (teleportTimer <= 0)
                {
                    ActivateCurse();
                }
            }
        }
    }
}
