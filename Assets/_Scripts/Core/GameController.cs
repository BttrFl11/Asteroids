using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private GameStateController _gameStateController;

    [Inject]
    public void Construct(GameStateController stateController)
    {
        _gameStateController = stateController;
    }

    private void Start()
    {
        _gameStateController.ChangeState(GameState.Intro);
    }
}