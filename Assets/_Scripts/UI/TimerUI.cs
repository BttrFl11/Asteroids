using TMPro;
using UnityEngine;
using Zenject;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _inGameTimerText;
    [SerializeField] private TextMeshProUGUI _gameOverTimerText;

    private Timer _timer;
    private GameStateController _gameStateController;

    [Inject]
    public void Construct(Timer timer, GameStateController stateController)
    {
        _timer = timer;
        _gameStateController = stateController;
        _gameStateController.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _gameStateController.OnGameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        _inGameTimerText.gameObject.SetActive(false);
        _gameOverTimerText.gameObject.SetActive(true);
        _gameOverTimerText.text = _timer.Time.ToString("0.0");
    }

    private void Update()
    {
        if (_gameStateController.State != GameState.GameOver)
            _inGameTimerText.text = _timer.Time.ToString("0.0");
    }
}