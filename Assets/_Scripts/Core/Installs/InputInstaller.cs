using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    [SerializeField] private InputHandler _inputHandlerPrefab;

    public override void InstallBindings()
    {
        var inputHandler = Container.InstantiatePrefabForComponent<InputHandler>(_inputHandlerPrefab, Vector3.zero, Quaternion.identity, null);

        Container.Bind<InputHandler>().FromInstance(inputHandler).AsSingle();
    }
}