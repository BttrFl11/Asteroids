using UnityEngine;
using Zenject;

public class ShipShooting : MonoBehaviour
{
    private ShipShootingData _data;
    private ProjectileFactory _projectileFactory;
    private InputHandler _inputHandler;
    private float _startTimeBtwShots; // Btw - between
    private float _timeBtwShots;

    private bool CanShoot => _timeBtwShots <= 0;

    public ShipShootingData Data => _data;

    [Inject]
    public void Construct(InputHandler inputHandler, ShipData shipData)
    {
        _data = shipData.ShootingData;

        _startTimeBtwShots = 1 / Data.FireRate;
        _timeBtwShots = _startTimeBtwShots;

        _inputHandler = inputHandler;
        inputHandler.OnShoot += TryShoot;
    }

    private void Awake()
    {
        _projectileFactory = new(Data.ProjectilePrefab, Data.SuperProjectilePrefab);
    }

    private void OnDisable()
    {
        _inputHandler.OnShoot -= TryShoot;
    }

    private void Update()
    {
        _timeBtwShots -= Time.deltaTime;
    }

    private void TryShoot()
    {
        if (CanShoot)
            Shoot();
    }

    private void Shoot()
    {
        _projectileFactory.CreateProjectile(transform.position, transform.rotation);

        _timeBtwShots = _startTimeBtwShots;
    }
}