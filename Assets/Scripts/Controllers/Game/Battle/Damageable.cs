using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour, IDamageable
{
    private Health _health;
    void Start()
    {
        _health = GetComponent<Health>();
    }

    public void MakeDamage(int damage)
    {
        _health.DecreaseHealth(damage);
    }
}
