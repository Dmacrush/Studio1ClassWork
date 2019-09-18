using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : StateBase
{
    public Rigidbody rb;
    public int force;
    public bool isGrounded;
    public Collider touchingGround;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        touchingGround = GetComponent<Collider>();

    }
    
    public override void Execute()
    {
        JumpUp();
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = true;
    }

    public void JumpUp()
    {
        if (isGrounded)
        {
            rb.AddForce(force * Vector2.up);
            isGrounded = false;
        }
    }
}
