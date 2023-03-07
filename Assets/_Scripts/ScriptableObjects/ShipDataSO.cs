using UnityEngine;

[CreateAssetMenu(menuName = "SO/ShipData")]
public class ShipDataSO : ScriptableObject
{
    [SerializeField] private ShipMovementData _movementData;
    [SerializeField] private ShipFuelData _fuelData;
    [SerializeField] private ShipShootingData _shootingData;

    public ShipFuelData FuelData => _fuelData;
    public ShipMovementData MovementData => _movementData;
    public ShipShootingData ShootingData => _shootingData;
}