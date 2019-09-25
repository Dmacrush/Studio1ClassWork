using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : StateBase
{
    public Rigidbody rb;
    public int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public override void Execute()
    {
        Moveright();
        base.Execute();
    }

    public void Moveright()
    {
        rb.AddForce(force * Vector3.right);
    }
}
