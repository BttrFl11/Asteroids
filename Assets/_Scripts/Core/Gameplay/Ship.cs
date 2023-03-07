using UnityEngine;
using Zenject;

public class Ship : MonoBehaviour
{
    private ShipData _data;
    public ShipData Data => _data;

    private ShipMovement _movement;
    public ShipMovement Movement => _movement;

    [Inject]
    public void Construct(InputHandler inputHandler, ShipData shipData)
    {
        _data = shipData;
        var fuel = new ShipFuel(Data.FuelData);
        _movement = new ShipMovement(transform, fuel, Data.MovementData);

        inputHandler.OnMove += Movement.MoveForward;
        inputHandler.OnRotate += Movement.Rotate;
    }
}