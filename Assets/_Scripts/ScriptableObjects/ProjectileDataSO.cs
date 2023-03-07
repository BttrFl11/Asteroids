using UnityEngine;

[CreateAssetMenu(menuName ="SO/ProjectileData")]
public class ProjectileDataSO : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}