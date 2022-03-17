using UnityEngine;

public class ViewStorage : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroupPause;
    [SerializeField] private CanvasGroup _canvasGroupResume;
    [SerializeField] private CanvasGroup _canvasGroupGameOver;
    [SerializeField] private CanvasGroup _canvasGroupMenuInterface;

    public CanvasGroup canvasGroupPause => _canvasGroupPause;
    public CanvasGroup canvasGroupResume => _canvasGroupResume;
    public CanvasGroup canvasGroupGameOver => _canvasGroupGameOver;
    public CanvasGroup canvasGroupMenuInterface => _canvasGroupMenuInterface;
}