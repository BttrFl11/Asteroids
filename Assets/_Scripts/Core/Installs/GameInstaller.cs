using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Timer _timer;

    private GameStateController _gameStateController;

    public override void InstallBindings()
    {
        _gameStateController = new GameStateController();

        Container.Bind<GameStateController>().FromInstance(_gameStateController).AsSingle();

        Container.Bind<Timer>().FromInstance(_timer).AsSingle();
    }
}
