using UnityEngine;
using Zenject;

public class AsteroidSpawner : Spawner
{
    [SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private float _spawnRadius;

    private Transform _target;
    private float _startTimeBtwSpawns;
    private float _timeBtwSpawns;

    [Inject]
    public void Construct(Ship ship)
    {
        _target = ship.transform;
    }

    private void Awake()
    {
        _startTimeBtwSpawns = 1 / _spawnRate;
        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    private void Update()
    {
        if (_target == null) return;

        _timeBtwSpawns -= Time.deltaTime;

        if (_timeBtwSpawns <= 0)
            Spawn();
    }

    public override void Spawn()
    {
        CreateAsteroid();

        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    private Vector2 GetSpawnPosition()
    {
        var position = new Vector2(Random.onUnitSphere.x, Random.onUnitSphere.y).normalized * _spawnRadius;
        return position;
    }

    private void CreateAsteroid()
    {
        var position = GetSpawnPosition();
        var asteroid = Instantiate(_asteroidPrefab, position, Quaternion.identity);
        asteroid.Init(_target.position - asteroid.transform.position, false);
    }
}