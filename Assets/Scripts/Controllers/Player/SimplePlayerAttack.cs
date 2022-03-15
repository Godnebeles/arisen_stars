using UnityEngine;

public class SimplePlayerAttack : MonoBehaviour, IPauseHandler
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _attackCooldown = 0.1f;

    private float _nextFireTime = 0f;

    private bool _isPaused;

    private void Update()
    {
        if (_isPaused)
            return;

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

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }
}
