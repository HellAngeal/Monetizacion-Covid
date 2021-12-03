using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerV2 : MonoBehaviour
{
    GameObject scoreUITextGO;
    public GameObject PowerUpGO;
    public GameObject UniqueAugmentGO;
    public GameObject explosionGO;
    int hp=5;
    float speed;
    int PupR;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;

        scoreUITextGO = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        Behaviour();
    }

    void Behaviour()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "PlayerBullet") && hp > 0)
        {
            hp -= 1;
        }
        else if ((collision.tag == "Player") || (collision.tag == "PlayerBullet")&&hp==0)
        {
            PupR = Random.Range(0, 1);

            EnemyExplosion();

            scoreUITextGO.GetComponent<GameScore>().Score += 50;

            if (PupR == 0)
            {
                SpawnPowerUp();
            }
            else
            {
                SpawnUniqueAugment();
            }

            Destroy(gameObject);
        }
    }

    void EnemyExplosion()
    {
        GameObject explosion = Instantiate(explosionGO);
        explosion.transform.position = transform.position;
    }

    void SpawnPowerUp()
    {
        int chance;
        chance = Random.Range(1, 8);
        if (chance==1)
        {
            GameObject PowerUp = Instantiate(PowerUpGO);
            PowerUp.transform.position = transform.position;
        }
    }
    void SpawnUniqueAugment()
    {
        int chance;
        chance = Random.Range(1, 13);
        if (chance == 1)
        {
            GameObject UniqueAugment = Instantiate(UniqueAugmentGO);
            UniqueAugment.transform.position = transform.position;
        }
    }
}
