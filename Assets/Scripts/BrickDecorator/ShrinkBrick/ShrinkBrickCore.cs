using UnityEngine;

public class ShrinkBrickCore : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new ShrinkBrickDecorator(brick);
    }

}
