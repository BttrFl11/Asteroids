using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyDataSO _enemyData;
    [SerializeField] private float _offsetZ;

    private Transform _target;

    private EnemyDataSO Data => _enemyData;

    /// <summary>
    /// arg1 - fuel restore per death value
    /// </summary>
    public static event Action<float> OnEnemyDied;

    public void Init(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_target == null) return;

        Chase();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, Data.MovementData.MoveSpeed * Time.deltaTime);

        LookAtTarget();
    }

    private void LookAtTarget()
    {
        var distance = _target.position - transform.position;
        var zRot = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(zRot + _offsetZ, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Die();
    }

    private void Die()
    {
        OnEnemyDied?.Invoke(Data.FuelRestorePerDeath);

        Destroy(gameObject);
    }
}