using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimatePlayerAttack : MonoBehaviour, IPauseHandler
{
    [SerializeField] private GameObject _ultimateBulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private AudioSource _audio;


    [SerializeField] private float _attackCooldown = 0.1f;


    private const float DOUBLE_CLICK_TIME = 0.5f;
    private float _lastClickTime;
    private float _nextFireTime = 0f;


    private bool _isPaused;

   
    private void Update()
    {
        if (_isPaused)
            return;

        if( (IsMouseDoubleClicked() || IsTouchpadDoubleClicked()) && Time.time >= _nextFireTime)
        {
            _nextFireTime = Time.time + _attackCooldown;
            Instantiate(_ultimateBulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
            GetComponent<AudioSource>().Play();
        }

    }

    private bool IsTouchpadDoubleClicked()
    {
        return false;
    }

    private bool IsMouseDoubleClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            float clickTimeSince = Time.time - _lastClickTime;

            _lastClickTime = Time.time;

            if (Math.Abs(clickTimeSince) <= DOUBLE_CLICK_TIME)
                return true;
        }

        return false;
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }
}
