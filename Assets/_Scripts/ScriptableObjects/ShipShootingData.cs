using UnityEngine;

[System.Serializable]
public class ShipShootingData
{
    [SerializeField] private float _fireRate;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Projectile _superProjectilePrefab;

    public Projectile ProjectilePrefab => _projectilePrefab;
    public Projectile SuperProjectilePrefab => _superProjectilePrefab;
    public float FireRate => _fireRate;
}
