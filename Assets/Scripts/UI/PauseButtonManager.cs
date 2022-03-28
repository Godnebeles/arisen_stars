using UnityEngine;
using UnityEngine.UI;

public class PauseButtonManager : MonoBehaviour
{
    [SerializeField] private PauseManager _pauseManager;
    [SerializeField] private bool _setPaused;
    //private Button _pauseButton;
    

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener( () => _pauseManager.SetPaused(_setPaused) );
    }
}
