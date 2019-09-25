using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Door : MonoBehaviour
{

    public int multiTriggerNumber;
    public int triggers;

    public UnityEvent OnOpened;
    public void Triggered()
    {
        triggers++;

        if(triggers >= multiTriggerNumber)
        {
            Open();
        }
    }
    public void Open()
    {
        gameObject.SetActive(false);
        OnOpened.Invoke();
    }
        
}
