using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _attackCooldown = 0.1f;

    private float _nextFireTime = 0f;
    
    private void Update()
    {
        _audio.volume = PlayerPrefs.GetFloat("MusicVolume");

        if (Input.touchCount == 1 || Input.GetMouseButton(0))
        {
            if (Time.time > _nextFireTime)
            {
                _nextFireTime = Time.time + _attackCooldown;
                Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
                GetComponent<AudioSource>().Play();
            }
        }
    }

   
}
