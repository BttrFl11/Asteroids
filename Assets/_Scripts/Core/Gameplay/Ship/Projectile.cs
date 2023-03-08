using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] protected ProjectileDataSO _projectileData;
    protected ProjectileDataSO Data => _projectileData;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Data.Speed * Time.deltaTime * transform.up, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
