using System;
using UnityEngine;

public class ShipMovement
{
    private Transform _transform;
    private ShipFuel _fuel;
    private float _rotateSpeed;
    private float _moveSpeed;

    private bool CanMove => !_fuel.Empty;

    public ShipFuel Fuel => _fuel;

    public ShipMovement(Transform transform, ShipFuel fuel, ShipMovementData data)
    {
        _transform = transform;
        _fuel = fuel;
        _rotateSpeed = data.RotateSpeed;
        _moveSpeed = data.MoveSpeed;
    }

    public virtual void MoveForward()
    {
        if (!CanMove) return;

        var transform = _transform;
        transform.position += _moveSpeed * Time.deltaTime * transform.up;
        _transform = transform;

        _fuel.Expend();
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

    /// <summary>
    /// param1 - current fuel, param2 - max fuel value
    /// </summary>
    public event Action<float, float> OnFuelChanged;

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

        OnFuelChanged?.Invoke(_fuel, _maxFuel);
    }
}