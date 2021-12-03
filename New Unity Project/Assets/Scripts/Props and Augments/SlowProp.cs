using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowProp : MonoBehaviour
{
    float speed;
    GameObject player;
    public PlayerController pC;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        player = GameObject.FindGameObjectWithTag("Player");
        pC = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Behaviour();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && pC.UniqueLevel==0)
        {
            pC.speed = 1.5f;
        }
        else if (collision.tag == "Player" && pC.UniqueLevel == 1)
        {
            pC.speed = 2.25f;
        }
        else if(collision.tag == "Player" && pC.UniqueLevel == 2)
        {
            pC.speed = 3f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (pC.UniqueLevel == 0)
        {
            pC.speed = 3;
        }
        else if( pC.UniqueLevel == 1)
        {
            pC.speed = 4.5f;
        }
        else
        {
            pC.speed = 6f;
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
