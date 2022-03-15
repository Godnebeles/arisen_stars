using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{

    [SerializeField] private CanvasGroup _canvasGroupPause;
    [SerializeField] private CanvasGroup _canvasGroupResume;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private PauseManager _pauseManager;

    public void Start()
    {
        _pauseManager.OnPauseStateChangedEvent += OnPauseStateChanged;
    }

    public void OnPauseStateChanged(bool isEnabled)
    {
        _canvasGroupPause.IsEnableCanvasGroup(isEnabled);
        _canvasGroupResume.IsEnableCanvasGroup(isEnabled);
        _canvasGroup.IsEnableCanvasGroup(isEnabled);
    }

}
