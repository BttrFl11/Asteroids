using UnityEngine;
using System;
using Zenject;

public class InputHandler : MonoBehaviour, IInputHandler
{
    public event Action OnShoot;
    public event Action OnMove;
    public event Action<float> OnRotate;
    public event Action OnAnyKey;

    private GameStateController _gameStateConstroller;
    private bool _readShipInput = false;
    private bool _readUserInput = true;

    [Inject]
    public void Construct(GameStateController stateController)
    {
        _gameStateConstroller = stateController;
        _gameStateConstroller.OnPlaying += () => _readShipInput = true;
        _gameStateConstroller.OnIntro += () => _readShipInput = false;
        _gameStateConstroller.OnGameOver += () => _readShipInput = false;
    }

    private void OnDisable()
    {
        _gameStateConstroller.OnPlaying -= () => _readShipInput = true;
        _gameStateConstroller.OnIntro -= () => _readShipInput = false;
        _gameStateConstroller.OnGameOver -= () => _readShipInput = false;
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadUserInput()
    {
        if (Input.anyKeyDown)
            OnAnyKey?.Invoke();
    }

    public void ReadInput()
    {
        if (_readShipInput == true)
            ReadShipInput();

        if (_readUserInput == true)
            ReadUserInput();
    }

    private void ReadShipInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            OnShoot?.Invoke();

        if (Input.GetKey(KeyCode.W))
            OnMove?.Invoke();

        if (Input.GetKey(KeyCode.D))
            OnRotate?.Invoke(-1f);
        else if (Input.GetKey(KeyCode.A))
            OnRotate?.Invoke(1f);
    }
}