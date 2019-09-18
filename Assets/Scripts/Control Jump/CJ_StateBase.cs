using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CJ_StateBase : MonoBehaviour
{
    public StateManager state;
    
    public virtual void Enter()
    {

    }

    public virtual void Execute()
    {
        Debug.Log("Executed");
    }

    public virtual void Exit()
    {

    }
}
