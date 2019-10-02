using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public PlayerStateBase stateBase;
    private PlayerStats playerStats;


    public float damageTimer;
    public float damageTick = 2.0f;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log("Current Lives: " + playerStats.lives);
        if(collision.gameObject.CompareTag("Death") && playerStats.lives <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        }
        else if(collision.gameObject.CompareTag("Death") && playerStats.lives >= 0)
        {
            playerStats.lives -= 1;
        }
        else if (playerStats.lives >= playerStats.maxLives)
        {
            playerStats.lives = playerStats.maxLives;
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            damageTimer += Time.deltaTime;
            
        }

        if (damageTimer >= damageTick)
        {
            TakeDamage();
            
        }
        
        if (collision.gameObject.CompareTag("Death") && playerStats.lives <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        }
        //Debug.Log(damageTimer);
    }
    private void TakeDamage()
    {
        playerStats.lives -= 1;
        damageTimer = 0f;
    }
}
