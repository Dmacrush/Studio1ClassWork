using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : StateBase
{
    public Rigidbody rb;
    public int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public override void Execute()
    {
        MoveFowards();
        base.Execute();
    }

    public void MoveFowards()
    {
        rb.AddForce(force * Vector3.forward);
    }
}
