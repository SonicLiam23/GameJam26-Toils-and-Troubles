using UnityEngine;

public class ScreamBrickCore : BrickCore
{
    ScreamBrickDecorator decorator;
    protected override void Awake()
    {
        base.Awake();

        decorator = new ScreamBrickDecorator(brick);
        brick = decorator;
        
    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            decorator.StopEffect();
        }
    }
}
