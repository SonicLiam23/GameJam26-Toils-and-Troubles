using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BrickFSM))]
public class Brick : MonoBehaviour
{
    public Rigidbody2D rb;
    public BrickFSM fsm;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fsm = GetComponent<BrickFSM>();
        GameManager.Instance.Bricks.Add(this);
    }

    private void OnDestroy()
    {
        GameManager.Instance.Bricks.Remove(this);
    }
}
