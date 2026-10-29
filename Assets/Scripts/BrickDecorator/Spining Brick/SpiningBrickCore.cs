using UnityEngine;

public class SpiningBrickCore : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new SpiningBrickDecorator(brick);
    }

}
