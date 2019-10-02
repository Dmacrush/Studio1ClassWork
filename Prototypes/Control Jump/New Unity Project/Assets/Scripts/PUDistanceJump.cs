using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUDistanceJump : MonoBehaviour
{
    public float distanceToJump;
    private PlayerStats player;
    public void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        distanceToJump = 50f;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(distanceToJump, player.transform.position.y, player.transform.position.z);

        }
    }
    

}
