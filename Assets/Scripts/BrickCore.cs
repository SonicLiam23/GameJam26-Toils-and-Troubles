using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BrickFSM))]
public class BrickCore : MonoBehaviour
{
    public Rigidbody2D rb;
    public BrickFSM fsm;

    public Brick brick;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fsm = GetComponent<BrickFSM>();
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
