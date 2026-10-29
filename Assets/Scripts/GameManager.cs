using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    public List<BrickCore> Bricks;

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
            if (b.fsm.GetState().GetType() != typeof(DraggingState))
            {
                b.fsm.ChangeState(typeof(PlacedState));
            }
        }
    }

    public void DestroyBlock(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
