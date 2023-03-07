using System;
using UnityEngine;

public class GameStateController
{
    private GameState _currentState;

    public GameState State => _currentState;

    public event Action OnIntro;
    public event Action OnPlaying;
    public event Action OnGameOver;

    public void ChangeState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Intro:
                OnIntro?.Invoke();
                break;
            case GameState.Playing:
                OnPlaying?.Invoke();
                break;
            case GameState.GameOver:
                OnGameOver?.Invoke();
                break;
        }

        _currentState = newState;
    }
}
