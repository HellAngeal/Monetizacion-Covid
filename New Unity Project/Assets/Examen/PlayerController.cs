using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    GameObject GameManagerGO;

    public float speed;
    public GameObject bulletPosition1;
    public GameObject bulletPosition2;
    public GameObject bullet01;
    public GameObject bullet02;
    public GameObject explosionGO;

    public GameObject LivesUIText;
    
    public int MaxLives = 5;

    GameManager GM;

    Text Livestext;

    int lives;
    // Start is called before the first frame update
    public void Start()
    {
        lives = MaxLives;

        Livestext.text = lives.ToString();
    }

    public void Awake()
    {
        GameManagerGO = GameObject.Find("GameManagerGO");
        GM=GameManagerGO.GetComponent<GameManager>();

        LivesUIText = GameObject.Find("CanvasGO");
        Livestext = LivesUIText.GetComponentInChildren<Text>();

        GM.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.Gameplay);
    }
    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            Move();
            if (Input.GetKeyDown("space"))
            {
                Shoot();
            }
        }
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
        Cmd_Shoot();
    }
    [Command]
    void Cmd_Shoot()
    {
        gameObject.GetComponent<AudioSource>().Play();

        GameObject bala1 = NetworkManager.Instantiate(bullet01);
        bullet01.transform.position = bulletPosition1.transform.position;
        NetworkServer.Spawn(bala1);

        GameObject bala2 = NetworkManager.Instantiate(bullet02);
        bullet02.transform.position = bulletPosition2.transform.position;
        NetworkServer.Spawn(bala2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy") || (collision.tag == "EnemyBullet"))
        {
            PlayerExplosion();

            UpdateLifes();

            if (lives <= 0)
            {
                GM.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
            }
        }
    }

    void PlayerExplosion()
    {
        Rpc_PlayerExplosion();
    }

    void Rpc_PlayerExplosion()
    {
        Cmd_PlayerExplosion();
    }

    [Command]
    void Cmd_PlayerExplosion()
    {
        GameObject explosion = NetworkManager.Instantiate(explosionGO);
        explosion.transform.position = transform.position;
        NetworkServer.Spawn(explosion);
    }

    void UpdateLifes()
    {
        Rpc_UpdateLifes();
    }

    void Rpc_UpdateLifes()
    {
        Cmd_UpdateLifes();
    }

    void Cmd_UpdateLifes()
    {
        lives--;
        Livestext.text = lives.ToString();
    }
}
