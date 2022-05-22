using System;
using UnityEngine;


public class Health : MonoBehaviour
{
    public event Action<HealthData> OnHealthChangedEvent;
    public event Action OnDeathEvent;
    
    private Characteristics _characteristics;
    
    private int _currentHealth;

    public int MaxHealthValue => _characteristics.MaxHealthValue;
    public int MinHealthValue => _characteristics.MinHealthValue;
    
    private void Awake()
    {
        OnDeathEvent += Kill;

        _characteristics = new Characteristics();
        
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