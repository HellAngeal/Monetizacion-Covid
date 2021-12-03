using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunV3 : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    public GameObject EnemyBulletGOL;
    public GameObject EnemyBulletGOR;
    public GameObject bulletPosition0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireEnemyBullet", 1f,3f);
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
            GameObject BalaC = Instantiate(EnemyBulletGO);
            BalaC.transform.position = bulletPosition0.transform.position;

            GameObject BalaL = Instantiate(EnemyBulletGOL);
            BalaL.transform.position = bulletPosition0.transform.position;

            GameObject BalaR = Instantiate(EnemyBulletGOR);
            BalaR.transform.position = bulletPosition0.transform.position;
        }
    }
}
