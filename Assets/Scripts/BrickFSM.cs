using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class BrickFSM : MonoBehaviour
{
    Dictionary<Type, BrickState> states;
    BrickState currentState;


    private void Awake()
    {
        states = new()
        {
            { typeof(DraggingState), new DraggingState(this) },
            { typeof(PlacedState), new PlacedState(this) },
            { typeof(LockedState), new LockedState(this) },
        };
    }

    private void Start()
    {
        ChangeState(typeof(DraggingState));
    }

    public void ChangeState(Type type)
    {
        currentState?.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public BrickState GetState()
    {
        return currentState;
    }

    private void Update()
    {
        currentState?.Update();   
    }



    // i hate this
    public bool inSpawnArea = true;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnArea")) 
        {
            inSpawnArea = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnArea"))
        {
            inSpawnArea = true;
        }
    }
}


public interface BrickState
{
    public void OnEnter();
    public void OnExit();
    public void Update();
}

public class DraggingState : BrickState
{
    float maxSpeed = 50f;
    float speed = 10f;
    BrickFSM fsm;
    public DraggingState(BrickFSM fsm)
    {
        this.fsm = fsm;
    }

    
    public void OnEnter()
    {
        fsm.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
        fsm.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnExit()
    {
        fsm.gameObject.GetComponent<Rigidbody2D>().linearDamping = 0f;
    }

    public void Update()
    {
        Vector3 toMouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - fsm.gameObject.transform.position;
        fsm.gameObject.GetComponent<Rigidbody2D>().linearVelocity = toMouseVector * speed;
        
        if (fsm.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude > maxSpeed)
        {
            fsm.gameObject.GetComponent<Rigidbody2D>().linearVelocity = fsm.gameObject.GetComponent<Rigidbody2D>().linearVelocity * maxSpeed;
        }

        fsm.gameObject.transform.position = new Vector3(fsm.gameObject.transform.position.x, fsm.gameObject.transform.position.y, 10);

        

        if (Input.GetMouseButtonUp(0))
        {
            fsm.ChangeState(typeof(PlacedState));
        }
    }
}

public class PlacedState : BrickState
{
    BrickFSM fsm;

    float timer = 0f;
    float lockTimer = 0.5f;
    Rigidbody2D rb;


    public PlacedState(BrickFSM fsm)
    {
        this.fsm = fsm;
    }

    public void OnEnter()
    {
        timer = 0f;
        rb = fsm.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.constraints = RigidbodyConstraints2D.None;
        fsm.gameObject.GetComponent<Collider2D>().excludeLayers = LayerMask.GetMask("Barrier");

    }

    public void OnExit()
    {
        
    }

    public void Update()
    {
        if (!fsm.inSpawnArea && rb.linearVelocity.magnitude <= 0.1 && Mathf.Abs(rb.angularVelocity) <= 0.01)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
        }



        if (timer > lockTimer)
        {
            if (Mathf.Abs(Mathf.DeltaAngle(rb.rotation, 0f)) <= 5f || Mathf.Abs(Mathf.DeltaAngle(rb.rotation, 180f)) <= 5f || Mathf.Abs(Mathf.DeltaAngle(rb.rotation, 90f)) <= 5f || Mathf.Abs(Mathf.DeltaAngle(rb.rotation, 270f)) <= 5f)
            {
                fsm.ChangeState(typeof(LockedState));
            }
            else
            {
                GameManager.Instance.DestroyBlock(fsm.gameObject);
                GameManager.Instance.UnlockAll();
            }
        }
    }
}

public class LockedState : BrickState
{

    BrickFSM fsm;
    public LockedState(BrickFSM fsm)
    {
        this.fsm = fsm;
    }
    public void OnEnter()
    {
        fsm.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void OnExit()
    {

    }

    public void Update()
    {

    }
}


