using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraLife : MonoBehaviour
{
    public PlayerStateBase stateBase;

    public void Awake()
    {
        stateBase = FindObjectOfType<PlayerStateBase>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(PlayerStateBase.lives >= PlayerStateBase.maxLives)
            {
                PlayerStateBase.lives = PlayerStateBase.maxLives;
            }
            else
            {
                PlayerStateBase.lives += 1;
            }
            Destroy(gameObject);

        }
    }

}
