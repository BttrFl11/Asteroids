using UnityEngine;

public class EnemySpawner : SpawnerBase<Enemy>
{
    protected override Enemy CreatePrefab()
    {
        var obj = base.CreatePrefab();
        obj.Init(_target);
        return obj;
    }
}