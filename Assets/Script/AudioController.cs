using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    [Header("Sound")]  
    private AudioSource audio;

    void Start()
    {
        
        audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("MusicVolume");
        
    }
    private void FixedUpdate()
    {
        
    }
}
