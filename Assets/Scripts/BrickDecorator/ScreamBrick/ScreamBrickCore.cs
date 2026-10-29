using UnityEngine;

public class ScreamBrickCore : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new ScreamBrickDecorator(brick);
    }
}
