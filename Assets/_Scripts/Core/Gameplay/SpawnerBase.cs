using UnityEngine;
using Zenject;

public abstract class SpawnerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T _prefab;
    [SerializeField] protected float _spawnRadius;
    [SerializeField] protected float _spawnRate;

    protected Transform _target;
    protected GameStateController _gameStateController;
    protected float _startTimeBtwSpawns;
    protected float _timeBtwSpawns;
    protected bool _stopSpawn;

    [Inject]
    public void Construct(Ship ship, GameStateController stateController)
    {
        _target = ship.transform;

        _gameStateController = stateController;
        _gameStateController.OnIntro += () => _stopSpawn = true;
        _gameStateController.OnGameOver += () => _stopSpawn = true;
        _gameStateController.OnPlaying += () => _stopSpawn = false;
    }

    protected virtual void OnDisable()
    {
        _gameStateController.OnIntro -= () => _stopSpawn = true;
        _gameStateController.OnGameOver -= () => _stopSpawn = true;
        _gameStateController.OnPlaying -= () => _stopSpawn = false;
    }

    protected virtual void Awake()
    {
        _startTimeBtwSpawns = 1 / _spawnRate;
        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    protected virtual void Update()
    {
        if (_target == null || _stopSpawn) return;

        _timeBtwSpawns -= Time.deltaTime;

        if (_timeBtwSpawns <= 0)
            Spawn();
    }

    protected virtual void Spawn()
    {
        CreatePrefab();

        _timeBtwSpawns = _startTimeBtwSpawns;
    }

    protected virtual Vector3 GetSpawnPosition()
    {
        var position = new Vector2(Random.onUnitSphere.x, Random.onUnitSphere.y).normalized * _spawnRadius;
        return position;
    }

    protected virtual T CreatePrefab()
    {
        var position = GetSpawnPosition() + _target.position;
        var obj = Instantiate(_prefab, position, Quaternion.identity);
        return obj;
    }
}