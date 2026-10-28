using JetBrains.Annotations;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    public float upForce = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
    }
}
