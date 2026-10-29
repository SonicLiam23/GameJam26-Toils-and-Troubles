using UnityEngine;

public class ExpandingBrickCore  : BrickCore
{
    protected override void Awake()
    {
        base.Awake();

        brick = new ExpandingBrickDecorator(brick);
    }

}
