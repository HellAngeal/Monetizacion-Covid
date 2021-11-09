using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public GameObject player;
    public GameObject enemySpawner;
    public GameObject gameOver;
    public GameObject scoreUITextGO;

    public enum GameManagerState
    {
        Gameplay,
        GameOver,
    }

    GameManagerState GMState;
    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Gameplay;
    }

    // Update is called once per frame
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Gameplay:

                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                break;
            case GameManagerState.GameOver:

                gameOver.SetActive(true);
                Application.Quit();
                break;
            default:
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGameplay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }
}
