using UnityEngine;

[CreateAssetMenu(menuName ="SO/EnemyData")]
public class EnemyDataSO : ScriptableObject
{
    [SerializeField] private MovementData _movementData;
    [SerializeField] private float _fuelRestorePerDeath;

    public MovementData MovementData => _movementData;
    public float FuelRestorePerDeath => _fuelRestorePerDeath;
}