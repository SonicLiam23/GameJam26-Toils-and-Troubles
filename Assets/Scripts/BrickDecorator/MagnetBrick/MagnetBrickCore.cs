using UnityEditor.SceneManagement;
using UnityEngine;

public class MagnetBrickCore : BrickCore
{

    CircleCollider2D col;
    protected override void Awake()
    {
        // ABSOLUTLEY MUST COME AT THE TOP OF YOUR AWAKE!!!
        base.Awake();

        // add your behavious for this brick like this! Change "ExampleBrickDecorator"
        // to your decorator type (the one inherting from BrickDecorator)
        brick = new MagnetBrickDecorator(brick);

        // you can stack behaviours of any type, e.g if you made an "Exploding brick, youd just also add"
        // brick = new ExplodingBrickDecorator(brick);

        // if you wanted some wild combinations you could do
        // brick = new ScreamingBrickDecorator(brick);
        // brick = new ExplodingBrickDecorator(brick);
        // brick = new GlowingBrickDecorator(brick);
        // and all behaviour would be applied automatically!

        gameObject.tag = "Magnet";
        col = gameObject.AddComponent<CircleCollider2D>();
        col.radius = 1f;
        col.isTrigger = true;
    }

    private void Start()
    {
        fsm.states.Remove(typeof(LockedState));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Magnet"))
        {
            Vector2 dir = this.transform.position - collision.transform.position;

            rb.AddForce(dir * 5f, ForceMode2D.Force);
        }
    }



}
