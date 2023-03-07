using UnityEngine;
using Zenject;

public class AsteroidSpawner : Spawner
{
    [SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private float _spawnRadius;

    private Transform _target;
    private GameStateController _gameStateController;
    private float _startTimeBtwSpawns;
    private float _timeBtwSpawns;
    private bool _stopSpawn;

    [Inject]
    public void Construct(Ship ship, GameStateController stateController)
    {
        _target = ship.transform;

        _gameStateController = stateController;
        _gameStateController.OnIntro += () => _stopSpawn = true;
        _gameStateController.OnGameOver += () => _stopSpawn = true;
        _gameStateController.OnPlaying += () => _stopSpawn = false;
    }

    private void OnDisable()
    {
        _gameStateController.OnIntro -= () => _stopSpawn = true;
        _gameStateController.OnGameOver -= () => _stopSpawn = true;
        _gameStateController.OnPlaying -= () => _stopSpawn = false;
    }

    private void Awake()
    {
        _startTimeBtwSpawns = 1 / _spawnRate;
        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    private void Update()
    {
        if (_target == null || _stopSpawn) return;

        _timeBtwSpawns -= Time.deltaTime;

        if (_timeBtwSpawns <= 0)
            Spawn();
    }

    public override void Spawn()
    {
        CreateAsteroid();

        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    private Vector3 GetSpawnPosition()
    {
        var position = new Vector2(Random.onUnitSphere.x, Random.onUnitSphere.y).normalized * _spawnRadius;
        return position;
    }

    private void CreateAsteroid()
    {
        var position = GetSpawnPosition() + _target.position;
        var asteroid = Instantiate(_asteroidPrefab, position, Quaternion.identity);
        asteroid.Init(_target.position - asteroid.transform.position, false);
    }
}