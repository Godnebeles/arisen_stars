using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

public class SimplePlayerAttack : MonoBehaviour, IPauseHandler
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _attackCooldown = 0.1f;
    [SerializeField] private ScoringCalculator _scoringCalculator;

    [SerializeField] private int _damage;

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
                Bullet bullet = Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation)
                    .GetComponent<Bullet>();
                bullet.SetDamage(_damage);
                bullet.OnDeathAction(OnEnemyKilling);
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnEnemyKilling()
    {
        _scoringCalculator.AddScore();
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }
}