using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StateBase : MonoBehaviour
{
    public StateManager stateManager;
    
    public virtual void Enter()
    {

    }
    public virtual void Execute()
    {
        

        //Debug.Log(lives);
    }
    public virtual void Exit()
    {

    }

    
}
