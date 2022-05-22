using System;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    //[Space]
    //[Header("Score Text")]
    public Text moneyAfterLoseText;

    [Header("Sound")]
    public Slider volumeSlider;
    private AudioSource audio;
    // 
    

    private void Start ()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        audio = GetComponent<AudioSource>();
        moneyAfterLoseText.text = "";
    }
    private void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }

}
