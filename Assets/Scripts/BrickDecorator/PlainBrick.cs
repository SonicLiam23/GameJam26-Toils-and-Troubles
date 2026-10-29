using UnityEngine;

public class PlainBrick : Brick
{
    public BrickCore Core { get; }
    public PlainBrick(BrickCore Core)
    {
        this.Core = Core;
    }

    public void ActivateCurse() { /* PLAIN BRICK, DO NOTHING */}

    public void ApplyCurse() { /* PLAIN BRICK, DO NOTHING */}

    public void UpdateCurse() { /* PLAIN BRICK, DO NOTHING */}
}
