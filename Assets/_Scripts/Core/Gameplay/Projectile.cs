using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected ProjectileData _projectileData;
    protected ProjectileData Data => _projectileData;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Data.Speed * Time.deltaTime * transform.up, Space.World);
    }
}
