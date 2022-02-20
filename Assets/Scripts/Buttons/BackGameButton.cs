using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGameButton : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject restart;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) // Проверка на нажатие кнопки "назад" на телефоне
        {
            if (pausePanel.activeSelf || !pausePanel.activeSelf && !restart.activeSelf)
            {
                pausePanel.SetActive(!pausePanel.activeSelf); // Включить, либо выключть панель с паузой
                if (pausePanel.activeSelf)
                {
                    Time.timeScale = 0f;
                }
                if (!pausePanel.activeSelf)
                {
                    Time.timeScale = 1f;
                }
            }
            if (restart.activeSelf) // Если активироана кнопка "restart"
            {
                SceneManager.LoadScene("mainMenu", LoadSceneMode.Single); // Загрузится в меню
            }
        }

    }
}
