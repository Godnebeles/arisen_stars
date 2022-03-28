using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Text _healthText;

    private void Start()
    {
        _healthSlider.maxValue = _playerHealth.MaxHealthValue;
        _healthSlider.value = _playerHealth.MaxHealthValue;
        _healthText.text = System.Convert.ToString(_playerHealth.MaxHealthValue);
        _playerHealth.OnHealthChangedEvent += OnHealthValueChanged;
        _playerHealth.OnDeathEvent += OnDeath;
    }

    private void OnDeath()
    {
        _healthSlider.value = _healthSlider.minValue;
        _healthText.text = _playerHealth.MinHealthValue.ToString();
    }

    private void OnHealthValueChanged(HealthData healthData)
    {
        _healthSlider.value = healthData.newHealth;
        _healthText.text = System.Convert.ToString(healthData.newHealth);
    }
}
