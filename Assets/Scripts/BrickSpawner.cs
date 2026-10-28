using System.Data.Common;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;
    public float[] sizes;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject brick = GameObject.Instantiate(brickPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation);
            float size = sizes[Random.Range(0, sizes.Length)];
            brick.transform.localScale = new Vector3(size * 1.5f, size, 0);
            brick.transform.position += new Vector3(0, 0, 10);
        }
    }
}