using UnityEngine;
using Zenject;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;

    private GameStateController _gameStateController;

    [Inject]
    public void Construct(GameStateController stateController)
    {
        _gameStateController = stateController;
        _gameStateController.OnGameOver += Show;
    }

    private void Awake()
    {
        _uiPanel.SetActive(false);
    }

    private void Show()
    {
        _uiPanel.SetActive(true);

        _gameStateController.OnGameOver -= Show;
    }
}