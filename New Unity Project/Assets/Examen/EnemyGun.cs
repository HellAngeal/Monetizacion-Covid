using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class EnemyGun : NetworkBehaviour
{
    public GameObject EnemyBulletGO;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
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
            GameObject BalaE = NetworkManager.Instantiate(EnemyBulletGO);
            BalaE.transform.position = transform.position;
            NetworkServer.Spawn(BalaE);

            Vector2 direction = playerShip.transform.position - BalaE.transform.position;

            BalaE.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
