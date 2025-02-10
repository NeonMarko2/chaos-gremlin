using System;
using UnityEngine;

public class CombatMode : GameStateMode
{
    public int EnemiesLeft;

    public event Action StartSpawning;
    public event Action StopSpawning;

    private void Start()
    {
        GameManager.Instance.GameStateChanged += GameStateChanged;
    }

    private void GameStateChanged(GameState state)
    {
        if(state == GameState.GameOver)
        {
            StopSpawning?.Invoke();
        }
    }

    public override void OnMode()
    {
        int enemyCount = 10 + 5 * GlobalStats.FloorsCleared;
        EnemiesLeft = UnityEngine.Random.Range(enemyCount - 3, enemyCount + 3);
        StartSpawning?.Invoke();
    }

    public void RemoveEnemy()
    {
        if (GameManager.Instance.CurrentGameState != GameState.Playing)
            return;

        EnemiesLeft--;
        GlobalStats.EnemiesKilled += 1;

        if (EnemiesLeft <= 0)
        {
            Camera.main.GetComponent<NegativeScreenFlash>().StartScreenFlash(.1f);
            GameManager.Instance.SetGameState(GameState.FloorCleared);
            StopSpawning?.Invoke();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameManager.Instance.SetGameState(GameState.FloorCleared);
            StopSpawning?.Invoke();
        }
    }
}
