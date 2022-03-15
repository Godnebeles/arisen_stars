using UnityEngine;

public class GameStateSwitcher : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameState _gameState;


    private void Start()
    {
        _health.OnPlayerDeathEvent += OnPlayerDeath;
    }

    private void OnPlayerDeath(HealthData healthData)
    {
        _gameState.SetGameOver();
    }

    public void SetPause()
    {
        _gameState.SetPause();
    }
}
