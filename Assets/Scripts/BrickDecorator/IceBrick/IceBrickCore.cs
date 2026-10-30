using UnityEngine;

public class IceBrickCore : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new IceBrickDecorator(brick);
    }

}
