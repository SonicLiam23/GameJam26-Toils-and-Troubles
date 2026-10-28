using UnityEngine;

public abstract class BrickDecorator : Brick
{
    protected Brick decoratedBrick;
    public BrickCore Core => decoratedBrick.Core;

    public BrickDecorator(Brick decoratedBrick)
    {
        this.decoratedBrick = decoratedBrick;
    }

    public virtual void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
    }

    public virtual void ApplyCurse()
    {
        decoratedBrick.ApplyCurse();
    }

    public virtual void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();
    }
}
