using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : StateBase
{
    public Rigidbody rb;
    public int force;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    public override void Execute()
    {
        Moveleft();
        base.Execute();
    }

    public void Moveleft()
    {
        rb.AddForce(force * Vector3.left);
    }


}
