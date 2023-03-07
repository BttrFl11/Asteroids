using UnityEngine;

[System.Serializable]
public class ShipFuelData
{
    [SerializeField] private float _maxFuel;
    [SerializeField] private float _expendRate;

    public float MaxFuel => _maxFuel;
    public float ExpendRate => _expendRate;
}
