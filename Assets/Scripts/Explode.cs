using UnityEngine;

public class Explode : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.Instance.UnlockAll();

            foreach (BrickCore b in GameManager.Instance.Bricks)
            {
                Vector2 vel = b.transform.position - transform.position;
                b.rb.AddForce(vel * 5, ForceMode2D.Impulse);
            }
        }
    }
}
