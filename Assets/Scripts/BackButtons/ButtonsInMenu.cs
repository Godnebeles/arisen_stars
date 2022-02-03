using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsInMenu : MonoBehaviour
{
    [Header("Music")]
    private AudioSource audio;
    public GameObject settings;
    public Slider slider;
    [Header("Shop")]
    public GameObject shopPanel;
    public GameObject upgradePanel;
    private bool shopOpened;

    private void Start()
    {
        shopOpened = false;
        slider.value = PlayerPrefs.GetFloat("MusicVolume");
        audio = GetComponent<AudioSource>();
    }

    public void StartGame()
    {

        SceneManager.LoadScene("game", LoadSceneMode.Single);

        
    }
    public void ExitGame()
    {

        Application.Quit();
    }
    public void Settings()
    {
        settings.SetActive(!settings.activeSelf);
    }
    private void Update()
    {
        
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        
        PlayerPrefs.SetFloat("MusicVolume", slider.value);
    }

    public void ShopOpen()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    public void ClouseShop()
    {
        shopPanel.SetActive(false);
    }
    public void ClouseUpgrades()
    {
        upgradePanel.SetActive(false);
    }
    public void OpenUpgrade() 
    {
        upgradePanel.SetActive(true);    
    }
    

}
