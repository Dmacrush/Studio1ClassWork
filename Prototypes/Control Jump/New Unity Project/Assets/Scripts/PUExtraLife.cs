using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraLife : MonoBehaviour
{
    public PlayerStateBase stateBase;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(stateBase.lives >= stateBase.maxLives)
            {
                stateBase.lives = stateBase.maxLives;
            }
            else
            {
                stateBase.lives += 1;
            }
            Destroy(gameObject);

        }
    }

}
