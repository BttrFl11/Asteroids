using Zenject;
using UnityEngine;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Ship _shipPrefab;
    [SerializeField] private ShipDataSO _shipData;

    public override void InstallBindings()
    {
        BindShipData();
        BindShip();
    }

    private void BindShipData()
    {
        Container.Bind<ShipDataSO>().FromInstance(_shipData).AsSingle();
    }

    private void BindShip()
    {
        var shipInstance = Container.InstantiatePrefabForComponent<Ship>(_shipPrefab, Vector3.zero, Quaternion.identity, null);
        Container.Bind<Ship>().FromInstance(shipInstance).AsSingle();
    }
}
