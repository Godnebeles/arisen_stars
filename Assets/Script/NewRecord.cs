using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRecord : MonoBehaviour
{
    
    
    void Start()
    {
        GetComponent<Text>().text = "Your record: " + PlayerPrefs.GetInt("Score").ToString();
    }
    private void Update()
    {
        
        
        GetComponent<Text>().text = "Best score: " + PlayerPrefs.GetInt("Score").ToString();
    }

}    
