using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public event Action<HealthData> OnHealthChangedEvent;
    public event Action OnDeathEvent;

    private int _health;
    
    [SerializeField] private int _startHealth;
    public int MaxHealthValue { get; private set; }
    public int MinHealthValue { get; private set; } = 0;

    private void Awake()
    {
        OnDeathEvent += Kill;
        
        MaxHealthValue = PlayerPrefs.GetInt("MaxHealth");
        
        if (MaxHealthValue <= MinHealthValue)
            MaxHealthValue = _startHealth;

        _health = MaxHealthValue;
    }

    public bool DecreaseHealth(int points)
    {
        int oldHealthValue = _health;
        _health -= points;

        HealthData healthData = new HealthData(oldHealthValue, _health);

        if (_health <= MinHealthValue)
        {
            healthData.newHealth = MinHealthValue;
            OnDeathEvent?.Invoke();
        }
        else
        {
            OnHealthChangedEvent?.Invoke(healthData);
        }

        return _health > MinHealthValue;
    }

    public void IncreaseHealth(int points)
    {
        int oldHealthValue = _health;
        _health += points;

        OnHealthChangedEvent?.Invoke(new HealthData(oldHealthValue, _health));
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}