using Zenject;
using UnityEngine;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Ship _shipPrefab;
    [SerializeField] private ShipData _shipData;

    public override void InstallBindings()
    {
        BindShipData();
        BindShip();
    }

    private void BindShipData()
    {
        Container.Bind<ShipData>().FromInstance(_shipData).AsSingle();
    }

    private void BindShip()
    {
        var shipInstance = Container.InstantiatePrefabForComponent<Ship>(_shipPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<Ship>().FromInstance(shipInstance).AsSingle();
    }
}
