using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerStateBase : MonoBehaviour
{
    public PlayerStateManager stateManager;
    
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
