using UnityEngine;

[System.Serializable]
public class MovementData
{
    [SerializeField] private float _moveSpeed;

    public float MoveSpeed => _moveSpeed;
}

[System.Serializable]
public class ShipMovementData : MovementData
{
    [SerializeField] private float _rotateSpeed;

    public float RotateSpeed => _rotateSpeed;
}