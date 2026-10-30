using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class BrickFSM : MonoBehaviour
{
    public Dictionary<Type, BrickState> states;
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
        if (!states.ContainsKey(type)) return;

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

    public bool CompareCurrentState(Type state)
    {
        return states[state] == currentState;
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

    Rigidbody2D rb;
    public DraggingState(BrickFSM fsm)
    {
        this.fsm = fsm;
    }

    
    public void OnEnter()
    {
        rb = fsm.gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnExit()
    {
        rb.linearDamping = 0f;
    }

    public void Update()
    {
        Vector3 toMouseVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - fsm.gameObject.transform.position;
        rb.linearVelocity = toMouseVector * speed;
        
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
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
        if (rb.linearVelocity.magnitude <= 0.1 && Mathf.Abs(rb.angularVelocity) <= 0.01)
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


