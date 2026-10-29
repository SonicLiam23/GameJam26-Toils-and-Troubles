using UnityEngine;

public class WalkBrickCore : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new WalkBrickDecorator(brick);
    }
}
