using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUIncreaseScoreMultiplier : MonoBehaviour
{
    private PlayerStats player;
    public void Start()
    {
        player = FindObjectOfType<PlayerStats>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.scoreMultiplier += 1;
            Destroy(gameObject);

        }
    }


}
