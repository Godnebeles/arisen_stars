using System;
using UnityEngine;


public class Health : MonoBehaviour
{
    public event Action<HealthData> OnHealthChangedEvent;
    public event Action OnDeathEvent;

    [SerializeField] private int _startHealth;
    [SerializeField] private Characteristics _playerCharacteristics;
    
    private int _currentHealth;
    private int _maxHealthValue;
    private const int _minHealthValue = 0;
    public int MaxHealthValue { get; private set; }
    public int MinHealthValue
    {
        get => _maxHealthValue;
        set { return; }
    }
    

    private void Awake()
    {
        OnDeathEvent += Kill;

        MaxHealthValue = PlayerPrefs.GetInt("MaxHealth");

        if (MaxHealthValue <= MinHealthValue)
            MaxHealthValue = _startHealth;

        _currentHealth = MaxHealthValue;
    }

    public bool DecreaseHealth(int points) // do damage and get boolean value this object died or not
    {
        int oldHealthValue = _currentHealth;
        _currentHealth -= points;

        HealthData healthData = new HealthData(oldHealthValue, _currentHealth);

        if (_currentHealth <= MinHealthValue)
        {
            healthData.newHealth = MinHealthValue;
            OnDeathEvent?.Invoke();
        }
        else
        {
            OnHealthChangedEvent?.Invoke(healthData);
        }

        return _currentHealth > MinHealthValue;
    }

    public void IncreaseHealth(int points)
    {
        int oldHealthValue = _currentHealth;
        _currentHealth += points;

        OnHealthChangedEvent?.Invoke(new HealthData(oldHealthValue, _currentHealth));
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}