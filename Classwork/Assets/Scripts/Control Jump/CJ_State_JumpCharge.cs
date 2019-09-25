using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CJ_State_JumpCharge : CJ_StateBase
{
    public Rigidbody rb;
    public float timer;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public override void Execute()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow)) ;
        {
            Jump(timer);
        }
        
        base.Execute();
    }
    
    /*
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) ;
        {
            Jump(timer);
        }
    }
    */
    
    public void Jump(float time)
    {
        rb.AddForce(time * Vector3.up);
        timer = 0f;
    }
}
