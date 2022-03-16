using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    private Health _health;
    private bool _isAlive = true;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDeathEvent += OnDeath;
    }

    private void OnDeath()
    {
        _isAlive = false;
    }
    
    public bool MakeDamage(int damage)
    {
        return _health.DecreaseHealth(damage);
    }
}
