using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStateManager : MonoBehaviour
{
    public PlayerStateBase currentState;

    public PlayerStateBase chargeJump;
    public PlayerStateBase airborne;
    

    private PlayerStateBase previousState;

    public Transform spawnPoint;

    void Start()
    {
        chargeJump = GetComponent<ChargeJump>();
        airborne = GetComponent<AirBorne>();
        transform.position = spawnPoint.position;
        currentState = airborne;
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
        newState.Execute();
        currentState = newState;
        
    }
}
