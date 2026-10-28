using System.Data.Common;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brickPrefab;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject brick = GameObject.Instantiate(brickPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation);
            brick.transform.position += new Vector3(0, 0, 10);
        }
    }
}
