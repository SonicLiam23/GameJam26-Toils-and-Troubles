using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BrickFSM))]
public class BrickCore : MonoBehaviour
{
    public Rigidbody2D rb;
    public BrickFSM fsm;

    public Brick brick;


    public SpriteRenderer spriteRenderer;

    public Color Colour
    {
        get
        {
            return spriteRenderer.color;
        }
        set
        {
            spriteRenderer.color = value;
        }
    }

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fsm = GetComponent<BrickFSM>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        brick = new PlainBrick(this);
        GameManager.Instance.Bricks.Add(this);
    }

    private void Start()
    {
        brick.ApplyCurse();
    }

    private void Update()
    {
        brick.UpdateCurse();
    }

    private void OnDestroy()
    {
        GameManager.Instance.Bricks.Remove(this);
    }

}
