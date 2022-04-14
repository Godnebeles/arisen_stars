using UnityEngine;
using UnityEngine.Serialization;

public class SimplePlayerAttack : MonoBehaviour, IPauseHandler
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private float _attackCooldown = 0.1f;
    [FormerlySerializedAs("_scoringCalculator")] [SerializeField] private ScoreCalculator scoreCalculator;
    [SerializeField] private int _damage;
    [SerializeField] private float _nextFireTime = 0f;

    [SerializeField] private int _layer;
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
                Damager damager = Instantiate(_bulletPrefab, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation)
                    .GetComponent<Damager>();
                damager.SetDamage(_damage);
                damager.OnDeathAction(OnEnemyKilling);
                damager.gameObject.layer = _layer;
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnEnemyKilling()
    {
        scoreCalculator.AddScore();
    }

    public void SetPaused(bool isPaused)
    {
        _isPaused = isPaused;
    }
}