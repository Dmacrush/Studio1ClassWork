using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour
{
    public PlayerStateBase stateBase;

    public float damageTimer;
    public float damageTick = 2.0f;
    
    private void OnTriggerEnter(Collider collision)
    {
        
        Debug.Log("Current Lives: " + PlayerStateBase.lives);
        if(collision.gameObject.CompareTag("Death") && PlayerStateBase.lives <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        }
        else if(collision.gameObject.CompareTag("Death") && PlayerStateBase.lives >= 0)
        {
            PlayerStateBase.lives -= 1;
        }
        else if (PlayerStateBase.lives >= PlayerStateBase.maxLives)
        {
            PlayerStateBase.lives = PlayerStateBase.maxLives;
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
        
        if (collision.gameObject.CompareTag("Death") && PlayerStateBase.lives <= 0)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

        }
        Debug.Log(damageTimer);
    }
    private void TakeDamage()
    {
        PlayerStateBase.lives -= 1;
        damageTimer = 0f;
    }
}
