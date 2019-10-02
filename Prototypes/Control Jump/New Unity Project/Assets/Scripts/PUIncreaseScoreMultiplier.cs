using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUIncreaseScoreMultiplier : MonoBehaviour
{
    
    public void Awake()
    {

        
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UI.scoreMultiplier += 1;
            Destroy(gameObject);

        }
    }


}
