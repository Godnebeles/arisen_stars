using UnityEngine;

public class GameStateSwitcher : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameState _gameState;


    private void Awake()
    {
        _health.OnDeathEvent += OnDeath;
    }

    private void OnDeath()
    {
        _gameState.SetGameOver();
    }

    public void SetPause()
    {
        _gameState.SetPause();
    }
}
