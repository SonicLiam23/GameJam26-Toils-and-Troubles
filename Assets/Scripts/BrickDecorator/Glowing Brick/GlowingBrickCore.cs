using UnityEngine;

public class GlowingBrickCore : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new GlowingBrickDecorator(brick);
    }

}