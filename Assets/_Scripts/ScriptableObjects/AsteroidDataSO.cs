using UnityEngine;

[CreateAssetMenu(menuName = "SO/AsteroidData")]
public class AsteroidDataSO : ScriptableObject
{
    [SerializeField] private MovementData _movementData;
    [SerializeField] private Asteroid _subAsteroidPrefab;
    [SerializeField] private int _subAsteroidsCount;

    public Asteroid SubAsteroidPrefab => _subAsteroidPrefab;
    public int SubAsteroidsCount => _subAsteroidsCount;
    public MovementData MovementData => _movementData;
}