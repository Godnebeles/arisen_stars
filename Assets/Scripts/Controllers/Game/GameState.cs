using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;

    public void SetGameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void SetPause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
