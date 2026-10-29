using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BrickSpawner : MonoBehaviour
{
    public enum BRICK_TYPE
    {
        CURSED,
        PLAIN
    }

    [Range(0, 10), Tooltip("Out of 10, this is essentially the chance out of 10 to pull a cursed brick")]
    public int CursedCount = 4;

    public GameObject brickPrefab;

    List<Type> cursedTypes;

    List<BRICK_TYPE> brickPot;






    private void Awake()
    {
        cursedTypes = new()
        {
            typeof(TeleportBrickCore),
            typeof(SpiningBrickCore),
            typeof(ExpandingBrickCore),
            typeof(GlowingBrickCore)
            typeof(TeleportBrickCore),
            typeof(WalkBrickCore)
        };

        brickPot = new();
        GeneratePot();

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetBrick().SetActive(true);
        }
    }


    private void GeneratePot()
    {
        for (int i = 0; i < CursedCount; ++i)
        {
            brickPot.Add(BRICK_TYPE.CURSED);
        }

        for (int i = 0; i < (10 - CursedCount); ++i)
        {
            brickPot.Add(BRICK_TYPE.PLAIN);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>A disabled brick object. Enable when ready to place into scene</returns>
    private GameObject GetBrick()
    {
        GameObject brick = GameObject.Instantiate(brickPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation);
        brick.SetActive(false);

        if (brickPot.Count == 0)
        {
            GeneratePot();
        }

        int brickInd = Random.Range(0, brickPot.Count);
        BRICK_TYPE type = brickPot[brickInd];
        brickPot.RemoveAt(brickInd);

        if (type == BRICK_TYPE.CURSED) brick.AddComponent(cursedTypes[Random.Range(0, cursedTypes.Count)]);
        else brick.AddComponent<BrickCore>();

        brick.transform.position += new Vector3(0, 0, 10);

        return brick;
    }
}