using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenuPanel;


    private void Start()
    {
        
    }

   
    private void Update()
    {
        
    }

    public void SetPause()
    {
        _gameMenuPanel.SetActive(!_gameMenuPanel.active);
    }
}
