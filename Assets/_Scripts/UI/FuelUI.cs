using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FuelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fuelPercentText;
    [SerializeField] private Image _fuelImage;

    private Ship _ship;

    [Inject]
    public void Construct(Ship ship)
    {
        _ship = ship;
        _ship.Movement.Fuel.OnFuelChanged += UpdateUI;
    }

    private void OnDisable()
    {
        _ship.Movement.Fuel.OnFuelChanged -= UpdateUI;
    }

    private void UpdateUI(float fuel, float maxFuel)
    {
        var ratio = fuel / maxFuel;
        var percent = ratio * 100;
        _fuelPercentText.text = $"{percent:0.0}%";
        _fuelImage.fillAmount = ratio;
    }
}
