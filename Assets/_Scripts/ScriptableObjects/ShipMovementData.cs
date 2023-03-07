using UnityEngine;

[System.Serializable]
public class ShipMovementData
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    public float MoveSpeed => _moveSpeed;
    public float RotateSpeed => _rotateSpeed;
}