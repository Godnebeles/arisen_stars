using UnityEngine;

public class GameEndView : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private ViewStorage _viewStorage;
    
    private void Awake()
    {
        _playerHealth.OnDeathEvent += OnPlayerDeath;
    }

    private void OnPlayerDeath()
    {
        _viewStorage.canvasGroupPause.IsEnableCanvasGroup(true);
        _viewStorage.canvasGroupMenuInterface.IsEnableCanvasGroup(true);
        _viewStorage.canvasGroupGameOver.IsEnableCanvasGroup(true);
    }
}
