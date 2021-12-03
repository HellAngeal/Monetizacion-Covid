using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerV2 : MonoBehaviour
{
    public GameObject EnemyGO;

    float maxSpawnRate = 12f;
    // Start is called before the first frame update
    void Start()
    {
            Invoke("SpawnEnemy", maxSpawnRate);

            InvokeRepeating("IncreaseSpawnRate", 0f, 30f);    
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject Enemy = Instantiate(EnemyGO);
        Enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

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
