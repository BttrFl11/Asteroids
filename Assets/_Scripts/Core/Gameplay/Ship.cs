using UnityEngine;
using Zenject;

public class Ship : MonoBehaviour
{
    private InputHandler _inputHandler;
    private ShipDataSO _data;
    private ShipMovement _movement;
    private GameStateController _gameStateController;

    public ShipDataSO Data => _data;
    public ShipMovement Movement => _movement;

    [Inject]
    public void Construct(InputHandler inputHandler, ShipDataSO shipData, GameStateController stateController)
    {
        _data = shipData;
        var fuel = new ShipFuel(Data.FuelData);
        _movement = new ShipMovement(transform, fuel, Data.MovementData);

        _inputHandler = inputHandler;
        inputHandler.OnMove += Movement.MoveForward;
        inputHandler.OnRotate += Movement.Rotate;

        _gameStateController = stateController;
    }

    private void OnDisable()
    {
        _inputHandler.OnMove -= Movement.MoveForward;
        _inputHandler.OnRotate -= Movement.Rotate;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gameStateController.ChangeState(GameState.GameOver);

        Destroy(gameObject);
    }
}