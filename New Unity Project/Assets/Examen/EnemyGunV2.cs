using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunV2 : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 1f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.FindGameObjectWithTag("Player");

        if (playerShip != null)
        {
            GameObject BalaE = Instantiate(EnemyBulletGO);
            BalaE.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - BalaE.transform.position;

            BalaE.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
