using UnityEngine;
using UnityEngine.UI;

public class QuitGameButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    private void Awake()
    {
        _button.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
