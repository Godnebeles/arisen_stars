using System;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private int _damage;
    private Action OnDeathActionEvent;

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public void OnDeathAction(Action onHit)
    {
        OnDeathActionEvent += onHit;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            if (!damageable.MakeDamage(_damage))
            {
                OnDeathActionEvent?.Invoke();
            }

            Destroy(gameObject);
        }
    }
}