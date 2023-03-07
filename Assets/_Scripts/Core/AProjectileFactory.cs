using UnityEngine;

public abstract class AProjectileFactory
{
    protected Projectile _projectilePrefab;
    protected Projectile _superProjectilePrefab;

    public AProjectileFactory(Projectile projectilePrefab, Projectile superProjectilePrefab)
    {
        _projectilePrefab = projectilePrefab;
        _superProjectilePrefab = superProjectilePrefab;
    }

    public abstract Projectile CreateProjectile(Vector2 position, Quaternion rotation);
    public abstract Projectile CreateSuperProjectile(Vector2 position, Quaternion rotation);
}

public class ProjectileFactory : AProjectileFactory
{
    public ProjectileFactory(Projectile projectilePrefab, Projectile superProjectilePrefab) : base(projectilePrefab, superProjectilePrefab) { }

    public override Projectile CreateProjectile(Vector2 position, Quaternion rotation)
    {
        var projectile = Object.Instantiate(_projectilePrefab, position, rotation);
        return projectile;
    }

    public override Projectile CreateSuperProjectile(Vector2 position, Quaternion rotation)
    {
        var projectile = Object.Instantiate(_superProjectilePrefab, position, rotation);
        return projectile;
    }
}