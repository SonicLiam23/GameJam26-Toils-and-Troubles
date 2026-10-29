using UnityEngine;

public class TeleportBrickCore : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new TeleportBrickDecorator(brick);
    }
}
