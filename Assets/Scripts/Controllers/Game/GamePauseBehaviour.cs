using UnityEngine;

public class GamePauseBehaviour : MonoBehaviour, IPauseHandler
{

    public void SetPaused(bool isPaused)
    {
        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
