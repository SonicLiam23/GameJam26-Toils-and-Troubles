using UnityEngine;

public class CementBrickCore : BrickCore
{
    CementBrickDecorator dec;
    protected override void Awake()
    {
        
        // ABSOLUTLEY MUST COME AT THE TOP OF YOUR AWAKE!!!
        base.Awake();

        // add your behavious for this brick like this! Change "ExampleBrickDecorator"
        // to your decorator type (the one inherting from BrickDecorator)
        dec = new CementBrickDecorator(brick);
        brick = dec;
        spriteRenderer.sprite = GameManager.Instance.Cement;

        // you can stack behaviours of any type, e.g if you made an "Exploding brick, youd just also add"
        // brick = new ExplodingBrickDecorator(brick);

        // if you wanted some wild combinations you could do
        // brick = new ScreamingBrickDecorator(brick);
        // brick = new ExplodingBrickDecorator(brick);
        // brick = new GlowingBrickDecorator(brick);
        // and all behaviour would be applied automatically!
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall") && fsm.CompareCurrentState(typeof(PlacedState)) && collision.gameObject.GetComponent<CementBrickCore>() == null)
        {
            Destroy(collision.gameObject);
        }
    }

}
    