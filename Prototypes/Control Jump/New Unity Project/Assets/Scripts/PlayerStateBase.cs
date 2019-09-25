using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerStateBase : MonoBehaviour
{
    public PlayerStateManager stateManager;

    public int lives = 1;
    public int maxLives = 5;

    public virtual void Enter()
    {

    }
    public virtual void Execute()
    {
        

        //Debug.Log("Current State: " + stateManager.currentState);
    }
    public virtual void Exit()
    {

    }

    
}
