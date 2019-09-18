using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : StateBase
{
    public Rigidbody rb;
    public int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public override void Execute()
    {
        MoveBack();
        base.Execute();
    }

    public void MoveBack()
    {
        rb.AddForce(force * Vector3.back);
    }
}
