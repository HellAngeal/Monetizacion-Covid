using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletV3L : MonoBehaviour
{
    public float speed=5f;

    // Update is called once per frame
    void Update()
    {
            Vector2 position = transform.position;

            position = new Vector2(position.x - speed * Time.deltaTime, position.y - speed * Time.deltaTime);

            transform.position = position;

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if (transform.position.y > max.y)
            {
                Destroy(gameObject);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
