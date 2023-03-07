using UnityEngine;
using Zenject;

public class IntroScreen : MonoBehaviour
{
    [SerializeField] private GameObject _uiIntroPanel;

    private GameStateController _gameStateController;
    private InputHandler _inputHandler;

    [Inject]
    public void Construct(GameStateController stateController, InputHandler inputHandler)
    {
        _gameStateController = stateController;
        _gameStateController.OnIntro += ShowIntro;

        _inputHandler = inputHandler;
        _inputHandler.OnAnyKey += CloseIntro;
    }

    private void OnDisable()
    {
        _gameStateController.OnIntro -= ShowIntro;
    }

    private void ShowIntro()
    {
        _uiIntroPanel.SetActive(true);
    }

    private void CloseIntro()
    {
        _gameStateController.ChangeState(GameState.Playing);

        _uiIntroPanel.SetActive(false);

        _inputHandler.OnAnyKey -= CloseIntro;
    }
}