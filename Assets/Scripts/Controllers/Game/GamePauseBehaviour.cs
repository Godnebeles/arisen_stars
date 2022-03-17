using UnityEngine;

public class GamePauseBehaviour : IPauseHandler
{

    public void SetPaused(bool isPaused)
    {
        if (isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
