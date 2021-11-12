﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject GameManagerGO;

    public float speed;
    public GameObject bulletPosition1;
    public GameObject bulletPosition2;
    public GameObject explosionGO;
    public GameObject PlayerBulletGO;
    
    public int MaxLives;

    public Text Livestext;

    int lives;

    void Init()
    {
        lives = MaxLives;

        Livestext.text = lives.ToString();

        gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    public void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;

        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }
    void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = bulletPosition1.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = bulletPosition2.transform.position;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy") || (collision.tag == "EnemyBullet"))
        {
            PlayExplosion();

            lives--;
            Livestext.text = lives.ToString();

            if (lives == 0)
            {
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }
        }    
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(explosionGO);

        explosion.transform.position = transform.position;
    }
}