using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    public List<BrickCore> Bricks;


    // AS ALL DECORATORS ARE MADE THROUGH CODE, THERE ARE NO SCENE REFERENCES. SO. MAKE THEM HERE AND JUST ACCESS THEM WITH GameManager.Instance.VARIABLE;
    public AudioClip ScreamSFX;

    public GameObject BrickLight;
    public PhysicsMaterial2D IceMaterial;

    public TextMeshProUGUI timer;
    public float time;

    public Sprite ScreamingQuiet;
    public Sprite ScreamingLoud;
    public Sprite Glowing;
    public Sprite Expanding;
    public Sprite Ice;
    public Sprite Magnet;
    public Sprite Shrinking;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
            return;
        }

        Bricks = new();
    }


    public void UnlockAll()
    {
        foreach (BrickCore b in GameManager.Instance.Bricks)
        {
            if (b.fsm.CompareCurrentState(typeof(DraggingState))) continue;

            b.fsm.ChangeState(typeof(PlacedState));
        }
    }

    public void DestroyBlock(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        timer.text = "Time Remaining " + (time -= Time.deltaTime);
        if (time < 0)
        {
            Debug.Log("You Lose !!!");
        }
    }
}
