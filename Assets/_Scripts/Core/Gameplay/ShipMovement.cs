using UnityEngine;
using Zenject;

public class ShipMovement
{
    private Transform _transform;
    private ShipFuel _tank;
    private float _rotateSpeed;
    private float _moveSpeed;

    private bool CanMove => !_tank.Empty;

    public ShipMovement(Transform transform, ShipFuel tank, ShipMovementData data)
    {
        _transform = transform;
        _tank = tank;
        _rotateSpeed = data.RotateSpeed;
        _moveSpeed = data.MoveSpeed;
    }

    public virtual void MoveForward()
    {
        if (!CanMove) return;

        var transform = _transform;
        transform.position += _moveSpeed * Time.deltaTime * transform.up;
        _transform = transform;

        _tank.Expend();
    }

    public virtual void Rotate(float direction)
    {
        direction = Mathf.Clamp(direction, -1, 1);

        _transform.Rotate(Vector3.forward, direction * _rotateSpeed * Time.deltaTime, Space.World);
    }
}

public class ShipFuel
{
    private float _maxFuel;
    private float _fuel;
    private float _expendRate;

    public bool Empty => _fuel <= 0;

    public ShipFuel(ShipFuelData data)
    {
        _maxFuel = data.MaxFuel;
        _fuel = _maxFuel;
        _expendRate = data.ExpendRate;
    }

    public void Expend()
    {
        _fuel -= _expendRate * Time.deltaTime;
        if (_fuel < 0)
            _fuel = 0;
    }
}