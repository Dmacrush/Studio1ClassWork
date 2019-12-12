using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public PlayerStats player;
    public GameObject[] EnemyPrefabs;
    public GameObject[] powerups;
    public float enemySpawnTime;
    public float powerupTimer; 
    public float resetPowerupTimer;
    public AirBorne airBorne;

    private StateManager stateManager;
    private int timesSpawned;
    [Range(0,100)]
    public int maxEnemySpawn = 7;
    public int maxPowerupSpawn = 1;

    [SerializeField]
    private float maxX = 70f, minY = 0, maxY = 70f;

    
    public void Start()
    {

        timesSpawned = 0;
        maxX = 70f;
        maxY = 70f;
        resetPowerupTimer = 30;
        airBorne = GetComponent<AirBorne>();
        player = FindObjectOfType<PlayerStats>();

        StartCoroutine("SpawnEnemy");
        //int RandomEnemy = Random.Range(1, EnemyPrefabs.Length);
        //Instantiate(EnemyPrefabs[RandomEnemy], new Vector3(Random.Range(transform.position.x, transform.position.x + maxX), Random.Range(transform.position.y + minY, transform.position.y + maxY), transform.position.z), Quaternion.identity);
        //InvokeRepeating("Spawn", 0, enemySpawnTime);
    }
    /*
    public void Spawn()
    {
        float x = Random.Range(transform.position.x, transform.position.x + maxX);
        float y = Random.Range(transform.position.y + minY, transform.position.y + maxY);
        float z = transform.position.z;

        
        timesSpawned += 1;
        

        if (stateManager.currentState == stateManager.airborne)
        {
            timesSpawned = 0;
        }
        
        if (timesSpawned <= maxEnemySpawn)
        {
            powerupTimer += 1;
            SpawnEnemies(x, y, z);
        }

        if(powerupTimer >= resetPowerupTimer )
        {
            SpawnPowerUp(x, y, z);
        }

    }
    
    public void SpawnEnemies(float x, float y, float z)
    {
        int RandomEnemy = Random.Range(1, EnemyPrefabs.Length);
        Instantiate(EnemyPrefabs[RandomEnemy], new Vector3(x, y, z), Quaternion.identity);
    }

    public void SpawnPowerUp(float x, float y, float z)
    {
        int RandomPowerup = Random.Range(1, powerups.Length);
        Instantiate(powerups[RandomPowerup], new Vector3(x, y, z), Quaternion.identity);
        powerupTimer = 0;
    }
    */
    IEnumerator SpawnEnemy()
    {
        
        while (true)
        {
            float x = Random.Range(transform.position.x + 5, transform.position.x + maxX);
            float y = Random.Range(transform.position.y + minY, transform.position.y + maxY);
            float z = transform.position.z;
            int RandomEnemy = Random.Range(1, EnemyPrefabs.Length);
            int RandomPowerup = Random.Range(1, powerups.Length);

            timesSpawned += 1;


            if (player.inAir)
            {
                timesSpawned = 0;
            }

            if (timesSpawned <= maxEnemySpawn)
            {
                powerupTimer += 1;
                
                Instantiate(EnemyPrefabs[RandomEnemy], new Vector3(x, y, z), Quaternion.identity);
                yield return new WaitForSeconds(enemySpawnTime);
            }

            if (powerupTimer >= resetPowerupTimer)
            {
                
                Instantiate(powerups[RandomPowerup], new Vector3(x, y, z), Quaternion.identity);
                powerupTimer = 0;
                yield return new WaitForSeconds(enemySpawnTime);
            }
            yield return null;
        }

    }
}
