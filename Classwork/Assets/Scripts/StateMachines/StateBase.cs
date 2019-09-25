using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    public StateManager state;
    
    public virtual void Enter()
    {

    }

    public virtual void Execute()
    {
        Debug.Log("It Works");
    }

    public virtual void Exit()
    {

    }

}
