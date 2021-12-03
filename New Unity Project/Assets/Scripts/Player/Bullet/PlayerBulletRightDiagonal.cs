using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletRightDiagonal : MonoBehaviour
{
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        Vector2 position = transform.position;


        position = new Vector2(position.x + speed * Time.deltaTime, position.y + speed * Time.deltaTime);

        transform.position = position;
        transform.rotation = Quaternion.Euler(0, 0, -30);

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
