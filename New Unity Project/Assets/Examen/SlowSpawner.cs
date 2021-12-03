using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpawner : MonoBehaviour
{
    public GameObject SlowGO;

    public float maxSpawnRate = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnSlow", maxSpawnRate);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnSlow()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject Slow = Instantiate(SlowGO);
        Slow.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextSlowSpawn();
    }

    void ScheduleNextSlowSpawn()
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

        Invoke("SpawnSlow", spawnInSeconds);
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
