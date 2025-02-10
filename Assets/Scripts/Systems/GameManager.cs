using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentGameState;
    public event Action<GameState> GameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetGameState(CurrentGameState);
    }

    public void SetGameState(GameState newGameState)
    {
        CurrentGameState = newGameState;
        GameStateChanged?.Invoke(CurrentGameState);
    }
}

public enum GameState
{
    Playing,
    FloorCleared,
    Shopping,
    GameOver
}