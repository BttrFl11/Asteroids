using UnityEngine;

public class AsteroidSpawner : SpawnerBase<Asteroid>
{
    protected override Asteroid CreatePrefab()
    {
        var obj = base.CreatePrefab();
        obj.Init(_target.position - obj.transform.position, false);
        return obj;
    }
}