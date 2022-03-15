using UnityEngine;

public class SetVolume : MonoBehaviour
{
    private float musicVolume = 1f;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        audio.volume = musicVolume;
    }
    public void SetVolumeS(float vol)
    {
        musicVolume = vol;

    }
}
