using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueAugment : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = 1f;
    }

    void Update()
    {
        Behaviour();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
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
}
