using UnityEngine;

[CreateAssetMenu(menuName = "SO/ShipData")]
public class ShipData : ScriptableObject
{
    [SerializeField] private ShipMovementData _movementData;
    public ShipMovementData MovementData => _movementData;

    [SerializeField] private ShipFuelData _fuelData;
    public ShipFuelData FuelData => _fuelData;
}

[System.Serializable]
public class ShipFuelData
{
    [SerializeField] private float _maxFuel;
    [SerializeField] private float _expendRate;

    public float MaxFuel => _maxFuel;
    public float ExpendRate => _expendRate;
}

[System.Serializable]
public class ShipMovementData
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    public float MoveSpeed => _moveSpeed;
    public float RotateSpeed => _rotateSpeed;
}