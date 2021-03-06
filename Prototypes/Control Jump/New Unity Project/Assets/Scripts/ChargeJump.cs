﻿using System.Collections;
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
    [SerializeField]
    private float minJump;
    [SerializeField]
    private int jumpChargeRate = 50;
    public float maxJumpPressure;
    private PlayerStats player;

    
    private AirBorne airBorne;

    
    

    void Start()
    {
	    onGround = true;
	    jumpPressure = 0f;
        forwardForce = 5f;
	    minJump = 2f;
        minForwardForce = 2f;
        maxForwardForce = 70f;
	    maxJumpPressure = 50f;
        player = GetComponent<PlayerStats>();
        airBorne = GetComponent<AirBorne>();
    }
    public override void Execute()
    {
        
        base.Execute();
        player.rb.velocity = new Vector3(0,0,0);
        airBorne.maxForce = airBorne.originalMaxForce;
        
        airBorne.timer = 2f;
        //Debug.Log("Jump Pressure: " + jumpPressure);
        if (onGround)
        {
            if(Input.GetButton("Jump") || Input.GetKey(KeyCode.UpArrow))
            {
                if (jumpPressure <= maxJumpPressure)
                {
                    IncreaseJumpPressure();
                }
                else if(jumpPressure >= maxJumpPressure)
                {
                    DecreaseJumpPressure();
                }
                if (forwardForce <= maxForwardForce)
                {
                    IncreaseJumpAngle();
                }
                else if (forwardForce > maxForwardForce)
                {
                    DecreaseJumpAngle();
                }
            }

            else
            {
                if (jumpPressure > 0f) 
                {
                    jumpPressure += + minJump;
                    player.rb.velocity = new Vector3(jumpPressure * jumpPressure / forwardForce, jumpPressure, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                    player.inAir = true;
                    ChangeStates(GetComponent<AirBorne>());
                }
            }
        }
        
    }

    public void IncreaseJumpPressure()
    {
        jumpPressure += Time.deltaTime * jumpChargeRate;
    }

    public void DecreaseJumpPressure()
    {
        jumpPressure = minJump;
    }

    public void IncreaseJumpAngle()
    {
        forwardForce += 1f;
        //Debug.Log("Forward Force: " + forwardForce);
    }

    public void DecreaseJumpAngle()
    {
        forwardForce = minForwardForce;
        //Debug.Log("Forward Force: " + forwardForce);
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
