using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    public List<BrickCore> Bricks;



    // AS ALL DECORATORS ARE MADE THROUGH CODE, THERE ARE NO SCENE REFERENCES. SO. MAKE THEM HERE AND JUST ACCESS THEM WITH GameManager.Instance.VARIABLE;
    public PhysicsMaterial2D icyPhysicsMat;
    public AudioClip ScreamSFX;
    //fdjks
     
    public Sprite NormalBrick; 
    public Sprite ScreamingQuiet;
    public Sprite ScreamingLoud;
    public Sprite Glowing;
    public Sprite Expanding;
    public Sprite WalkingAway;
    public Sprite Spiral;
    public Sprite Cement;


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
}
