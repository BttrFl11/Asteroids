using UnityEngine;
using Zenject;

public class Timer : MonoBehaviour
{
    private GameStateController _gameStateController;
    private bool _record = false;
    private float _time = 0f;

    public float Time => _time;

    [Inject]
    public void Construct(GameStateController stateController)
    {
        _gameStateController = stateController;
        _gameStateController.OnPlaying += () => _record = true;
        _gameStateController.OnGameOver += () => _record = false;
    }

    private void OnDisable()
    {
        _gameStateController.OnPlaying -= () => _record = true;
        _gameStateController.OnGameOver -= () => _record = false;
    }

    private void Update()
    {
        if (_record)
        {
            _time += UnityEngine.Time.deltaTime;
        }
    }
}