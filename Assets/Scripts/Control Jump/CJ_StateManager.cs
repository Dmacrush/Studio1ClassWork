using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJ_StateManager : MonoBehaviour
{
   
    public StateBase currentStates;

    public StateBase CJ_State_JumpCharge;
    public StateBase CJ_State_Airborne;
    public StateBase CJ_State_Landing;

    public void Start()
    {
        ChangeStates(CJ_State_JumpCharge);
        currentStates.Execute();
    }

    public void Update()
    {
        
    }

    public void ChangeStates(StateBase newState)
    {
        currentStates.Exit();
        newState.Execute();
        currentStates = newState;
    }
}
