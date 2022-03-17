using UnityEngine;
using UnityEngine.Serialization;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private ViewStorage _viewStorage;
    [SerializeField] private PauseManager _pauseManager;

    public void Start()
    {
        _pauseManager.OnPauseStateChangedEvent += OnPauseStateChanged;
    }

    public void OnPauseStateChanged(bool isEnabled)
    {
        _viewStorage.canvasGroupPause.IsEnableCanvasGroup(isEnabled);
        _viewStorage.canvasGroupResume.IsEnableCanvasGroup(isEnabled);
        _viewStorage.canvasGroupMenuInterface.IsEnableCanvasGroup(isEnabled);
    }

}
