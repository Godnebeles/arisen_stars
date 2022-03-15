using UnityEngine;

public class Health : MonoBehaviour
{
    public delegate void HealthCallback(HealthData healthData);
    public event HealthCallback OnHealthChangedEvent;
    public event HealthCallback OnPlayerDeathEvent;

    private int _health;
    public int MaxHealthValue { get; private set; }
    public int MinHealthValue { get; private set; } = 0;

    private void Awake()
    {
        MaxHealthValue = PlayerPrefs.GetInt("MaxHealth");
        
        if (MaxHealthValue <= MinHealthValue)
            MaxHealthValue = 100;

        _health = MaxHealthValue;
    }

    public void DecreaseHealth(int points)
    {
        int oldHealthValue = _health;
        _health -= points;

        HealthData healthData = new HealthData(oldHealthValue, _health);

        if (_health <= MinHealthValue)
        {
            healthData.newHealth = MinHealthValue;
            OnPlayerDeathEvent?.Invoke( healthData);
            Kill();
        }
        else
        {
            OnHealthChangedEvent?.Invoke( healthData);
        }
    }

    public void IncreaseHealth(int points)
    {
        int oldHealthValue = _health;
        _health += points;

        OnHealthChangedEvent?.Invoke(new HealthData(oldHealthValue, _health));
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }
}

