using UnityEngine;
using Zenject;

public class Ship : MonoBehaviour
{
    private InputHandler _inputHandler;
    private ShipData _data;
    private ShipMovement _movement;

    public ShipData Data => _data;
    public ShipMovement Movement => _movement;

    [Inject]
    public void Construct(InputHandler inputHandler, ShipData shipData)
    {
        _data = shipData;
        var fuel = new ShipFuel(Data.FuelData);
        _movement = new ShipMovement(transform, fuel, Data.MovementData);

        _inputHandler = inputHandler;
        inputHandler.OnMove += Movement.MoveForward;
        inputHandler.OnRotate += Movement.Rotate;
    }

    private void OnDisable()
    {
        _inputHandler.OnMove -= Movement.MoveForward;
        _inputHandler.OnRotate -= Movement.Rotate;
    }
}