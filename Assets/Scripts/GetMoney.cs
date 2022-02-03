using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMoney : MonoBehaviour
{
    
    
    public Text money;
    public GameController score;

    
    void Update()
    {
        GetComponent<Text>().text = "Money: " + PlayerPrefs.GetInt("Moneys").ToString() + "$";

    }
    
    
}
