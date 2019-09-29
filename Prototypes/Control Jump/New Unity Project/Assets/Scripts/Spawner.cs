using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] enemyPrefabs;
    public float spawnTime;

    public PlayerStateManager stateManager;
    private int timesSpawned;
    public int maxSpawn = 7;

    [SerializeField]
    private float maxX = 70f, minY, maxY = 70f;

    
    public void Start()
    {
        timesSpawned = 0;
        int RandomEnemy = Random.Range(1, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[RandomEnemy], new Vector3(Random.Range(transform.position.x, transform.position.x + maxX), Random.Range(transform.position.y + minY, transform.position.y + maxY), transform.position.z), Quaternion.identity);
        Instantiate(enemyPrefabs[RandomEnemy], new Vector3(Random.Range(transform.position.x, transform.position.x + maxX), Random.Range(transform.position.y + minY, transform.position.y + maxY), transform.position.z), Quaternion.identity);
        Instantiate(enemyPrefabs[RandomEnemy], new Vector3(Random.Range(transform.position.x, transform.position.x + maxX), Random.Range(transform.position.y + minY, transform.position.y + maxY), transform.position.z), Quaternion.identity);
        Instantiate(enemyPrefabs[RandomEnemy], new Vector3(Random.Range(transform.position.x, transform.position.x + maxX), Random.Range(transform.position.y + minY, transform.position.y + maxY), transform.position.z), Quaternion.identity);
        Instantiate(enemyPrefabs[RandomEnemy], new Vector3(Random.Range(transform.position.x, transform.position.x + maxX), Random.Range(transform.position.y + minY, transform.position.y + maxY), transform.position.z), Quaternion.identity);
        InvokeRepeating("SpawnEnemies", 0, spawnTime);
        maxX = 70f;
        maxY = 70f;
    }

    public void SpawnEnemies()
    {
        timesSpawned += 1;
        if(stateManager.currentState == stateManager.airborne)
        {
            timesSpawned = 0;
        }

        float x = Random.Range(transform.position.x, transform.position.x + maxX);
        float y = Random.Range(transform.position.y + minY, transform.position.y + maxY);
        float z = transform.position.z;
        int RandomEnemy = Random.Range(1, enemyPrefabs.Length);

        if (timesSpawned <= maxSpawn)
        {
            Instantiate(enemyPrefabs[RandomEnemy], new Vector3(x, y, z), Quaternion.identity);
        }
       

        
    }

}
