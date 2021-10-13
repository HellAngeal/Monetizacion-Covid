using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject EnemyGO;

    float maxSpawnRate = 4f;
    // Start is called before the first frame update
    void Start()
    {
        if (isServer) 
        { 
            Invoke("SpawnEnemy", maxSpawnRate);

            InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject Enemy = NetworkManager.Instantiate(EnemyGO);
        Enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        NetworkServer.Spawn(Enemy);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInSeconds;

        if (maxSpawnRate > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRate);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInSeconds);
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRate > 1f)
        {
            maxSpawnRate--;
        }
        if (maxSpawnRate == 1f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }
}
