using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInGame : MonoBehaviour
{
    public bool gameIsPaused = false;
    public GameObject pauseMenu;
    public GameController score;
    
    public void Pause()
    {
        gameIsPaused = true;
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        
        gameIsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainMenu", LoadSceneMode.Single);
      
    }
    
}
