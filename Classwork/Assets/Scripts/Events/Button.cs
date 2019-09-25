using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Button : MonoBehaviour
{
    public UnityEvent onPressed;
    public class OnMultiPressEvent: UnityEvent<int>
    {

    }

    public OnMultiPressEvent OnMultiPress;

    private void OnTriggerEnter(Collider other)
    {
        if (onPressed != null) onPressed.Invoke();

        //question mark is the same as checking for null above
        OnMultiPress?.Invoke(2);
    }


}
