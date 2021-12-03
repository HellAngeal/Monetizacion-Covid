using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    GameObject scoreUITextGO;
    EnemySpawnerV2 ESpawnerV2;
    EnemySpawnerV3 ESpawnerV3;
    // Start is called before the first frame update
    void Start()
    {
        scoreUITextGO = GameObject.FindGameObjectWithTag("Score");
        ESpawnerV2 = gameObject.GetComponent<EnemySpawnerV2>();
        ESpawnerV3 = gameObject.GetComponent<EnemySpawnerV3>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlEnemySpawners();
    }

    void ControlEnemySpawners()
    {
        if (scoreUITextGO.GetComponent<GameScore>().Score > 200)
        {
            ESpawnerV2.GetComponent<EnemySpawnerV2>().enabled = true;
        }
        if (scoreUITextGO.GetComponent<GameScore>().Score > 300)
        {
            ESpawnerV3.GetComponent<EnemySpawnerV3>().enabled = true;
        }
    }
}
