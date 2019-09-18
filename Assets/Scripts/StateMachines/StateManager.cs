using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    public StateBase currentStates;

    public StateBase moveLeft;
    public StateBase moveRight;
    public StateBase moveUp;
    public StateBase moveDown;
    public StateBase jump;
    public StateBase grow;
    public StateBase shrink;

    
    
    void Update()
    {
        currentStates.Execute();
        if (transform.localScale.x >= 7)
        {
            ChangeStates(jump);
        }
        
        if (transform.localScale.x <=0.5 )
        {
            ChangeStates(jump);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeStates(moveLeft);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangeStates(moveDown);
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeStates(moveUp);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeStates(moveRight);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeStates(jump);
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeStates(grow);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeStates(shrink);
        }

    }

    public void ChangeStates(StateBase newState)
    {
        currentStates.Exit();
        newState.Execute();
        currentStates = newState;
    }
}
