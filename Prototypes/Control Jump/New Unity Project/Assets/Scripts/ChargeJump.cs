using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class ChargeJump : PlayerStateBase
{
    public bool onGround;
    public float jumpPressure;
    public float forwardForce;
    public float maxForwardForce;
    public float minForwardForce;
    public float minJump;
    public float maxJumpPressure;
    private Rigidbody rb;

    
    private AirBorne airBorne;

    
    

    void Start()
    {
	    onGround = true;
	    jumpPressure = 0f;
        forwardForce = 5f;
	    minJump = 2f;
        minForwardForce = 2f;
        maxForwardForce = 10f;
	    maxJumpPressure = 10f;
        rb = GetComponent<Rigidbody>();
        airBorne = GetComponent<AirBorne>();
        
    }
    public override void Execute()
    {
        
        base.Execute();
        airBorne.maxForce = airBorne.originalMaxForce;
        airBorne.timer = 2f;
        //Debug.Log("Jump Pressure: " + jumpPressure);
        if (onGround)
        {
            if(Input.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }
                
            }
            else
            {
                if (jumpPressure > 0f) 
                {
                    jumpPressure = jumpPressure + minJump;
                    rb.velocity = new Vector3(jumpPressure / forwardForce, jumpPressure, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                    ChangeStates(stateManager.airborne);
                }
            }

            if(Input.GetKeyDown(KeyCode.RightArrow) && forwardForce <= maxForwardForce)
            {

                forwardForce += 0.2f;
                Debug.Log("Forward Force: " + forwardForce);

            }
            else
            {
                forwardForce = maxForwardForce;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && forwardForce <= maxForwardForce)
            {

                forwardForce -= 0.2f;
                Debug.Log("Forward Force: " + forwardForce);
            }
            else
            {
                forwardForce = minForwardForce;
            }
        }
        
    }

    public void ChangeStates(PlayerStateBase stateBase)
    {
        stateManager.ChangeStates(stateBase);
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    */
}
