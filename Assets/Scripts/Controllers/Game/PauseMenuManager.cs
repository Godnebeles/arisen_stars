using UnityEngine;
using UnityEngine.Serialization;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private ViewStorage _viewStorage;
    [FormerlySerializedAs("_pauseManager")] [SerializeField] private Pause pause;

    public void Start()
    {
        pause.OnPauseStateChangedEvent += OnPauseStateChanged;
    }

    public void OnPauseStateChanged(bool isEnabled)
    {
        _viewStorage.canvasGroupPause.IsEnableCanvasGroup(isEnabled);
        _viewStorage.canvasGroupResume.IsEnableCanvasGroup(isEnabled);
        _viewStorage.canvasGroupMenuInterface.IsEnableCanvasGroup(isEnabled);
    }

}
