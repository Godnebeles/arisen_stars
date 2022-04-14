using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PauseButtonManager : MonoBehaviour
{
    [FormerlySerializedAs("_pauseManager")] [SerializeField] private Pause pause;
    [SerializeField] private bool _setPaused;
    //private Button _pauseButton;
    

    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener( () => pause.SetPaused(_setPaused) );
    }
}
