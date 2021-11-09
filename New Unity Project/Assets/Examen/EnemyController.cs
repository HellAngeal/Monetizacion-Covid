using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject scoreUITextGO;

    public GameObject explosionGO;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;

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
        if ((collision.tag == "Player") || (collision.tag == "PlayerBullet"))
        {
            EnemyExplosion();

            scoreUITextGO.GetComponent<GameScore>().Score += 10;

            Destroy(gameObject);
        }
    }

    void EnemyExplosion()
    {
        GameObject explosion = Instantiate(explosionGO);
        explosion.transform.position = transform.position;
    }
}
