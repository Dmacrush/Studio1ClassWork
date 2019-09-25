using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBorne : PlayerStateBase
{
    private ChargeJump chargeJump;

    public float maxForce, originalMaxForce;
    public Rigidbody rb;

    public float timer = 2f;
    public float maxHoverTime = 0f;

    public float resetAngle;

    private Vector3 forceVector;
    
    private void Start()
    {
        originalMaxForce = maxForce;
        rb = GetComponent<Rigidbody>();
        chargeJump = GetComponent<ChargeJump>();
    }

    public override void Execute()
    {
        base.Execute();

        if (Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow))
        {
            forceVector = Vector3.up * maxForce;
            timer -= Time.deltaTime;
            rb.AddForce(forceVector);
        }

        if (timer <= maxHoverTime)
        {
            maxForce = 0f;
            
            timer = 0f;
        }



        Debug.Log("Hover Time: " + timer);
        
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.CompareTag("Ground"))
        {
            chargeJump.onGround = true;
            chargeJump.forwardForce = chargeJump.minForwardForce;
            stateManager.ChangeStates(stateManager.chargeJump);

        }
        

    }
    
}
