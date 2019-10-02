using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUExtraLife : MonoBehaviour
{
    public PlayerStateBase stateBase;
    private PlayerStats player;
    public void Awake()
    {
        player = FindObjectOfType<PlayerStats>();
        stateBase = GetComponent<PlayerStateBase>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(player.lives >= player.maxLives)
            {
                player.lives = player.maxLives;
            }
            else
            {
                player.lives += 1;
            }
            Destroy(gameObject);

        }
    }

}
