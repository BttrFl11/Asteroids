using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected float _spawnRate;

    public abstract void Spawn();
}