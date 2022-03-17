using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [Space]
    [Header("MONEY")]
    public int moneyAfterLose;
    private int money;
    private int moneyForResult;

    [Space]
    [Header("Score Text")]
    public Text moneyAfterLoseText;
    [Space]
    [Header("Pause and Lose Menu")]
    public PauseInGame pause;
    private bool gameOver;
    private bool restartGame;

    [Header("Sound")]
    public Slider volumeSlider;
    AudioSource audio;
    
    private void Start ()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        audio = GetComponent<AudioSource>();
        moneyForResult = 0;
        moneyAfterLoseText.text = "";
    }
    private void Update()
    {

        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);

    }
    
    public void AddMoney(int MoneyValues)
    {
        // if (score > 2000 && score < 4000)
        // {
        //     MoneyValues *= 5;
        // }
        // if (score > 4000 && score < 8000)
        // {
        //     MoneyValues *= 10;
        // }
        // if (score > 8000 && score < 100000)
        // {
        //     MoneyValues *= 20;
        // }
        //money = MoneyValues + PlayerPrefs.GetInt("Moneys");
        //PlayerPrefs.SetInt("Moneys", money);
        //moneyForResult += MoneyValues;
    }

   public void UpEnemy()
    {
        // if (score > 2000 && score < 4000)
        // {
        //     maxHealthEnemy = 50;
        // }
        // if (score > 4000 && score < 8000)
        // {
        //     maxHealthEnemy = 75;
        // }
        // if (score > 8000 && score < 100000)
        // {
        //     maxHealthEnemy = 150;
        // }
    }
    public void DamageForPlayer(int damage, Collider other)
    {
        // if (score > 2000 && score < 4000)
        // {
        //     damage += 50;
        // }
        // else if (score > 4000 && score < 8000)
        // {
        //     damage += 75;
        // }
        // else 
        // {
        //     damage += 150;
        // }
    }

}
