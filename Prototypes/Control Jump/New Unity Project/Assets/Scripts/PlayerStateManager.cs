using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStateManager : MonoBehaviour
{
    public PlayerStateBase currentState;

    private PlayerStateBase previousState;

    public Transform spawnPoint;

    void Start()
    {
        
        transform.position = spawnPoint.position;
        
    }
    void Update()
    {
        currentState.Execute();
    }

    public void ChangeStates(PlayerStateBase newState)
    {
        previousState = currentState;
        //Debug.Log("Previous State: " + previousState);
        currentState.Exit();

        currentState = newState;
        newState.Enter();
        newState.Execute();
       
        
    }
}
