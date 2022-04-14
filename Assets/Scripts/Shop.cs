using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Save
{
    public int[] levelOfItem;
    public int[] cost;
}

[Serializable]
public class Item
{
    public int cost;
    [HideInInspector]
    public int levelOfItem ;
    public int costMultiplier;
    [Tooltip("Название используется на кнопках")]
    public string name;
    public int value;
    public int valueMultiply;
    public float valueSpeed;
    public float valueSpeedMyltiply;
}
public class Shopi : MonoBehaviour
{
    [Header("Кнопки товаров")]
    public Button[] shopBttns;
    [Header("Текст на кнопках товаров")]
    public Text[] shopItemsText;
    [Header("Текст значения учучшений")]
    public Text[] countUpgrades;
    [Header("Магазин")]
    public List<Item> shopItems = new List<Item>();
    private Save sv = new Save();
    
    private void Awake()
    {
        if (PlayerPrefs.HasKey("SV"))
        {
            sv = JsonUtility.FromJson<Save>(PlayerPrefs.GetString("SV"));
            
            for (int i = 0; i < shopItems.Count; i++)
            {
                shopItems[i].cost = sv.cost[i];
                shopItems[i].levelOfItem = sv.levelOfItem[i];                             
                shopItems[0].value += (shopItems[0].valueMultiply * shopItems[0].levelOfItem);
                shopItems[3].value += (shopItems[3].value * shopItems[3].levelOfItem);
                shopItems[1].value = shopItems[2].valueMultiply * shopItems[2].levelOfItem;
                shopItems[1].valueSpeed *= shopItems[1].levelOfItem;

                shopItemsText[i].text = shopItems[i].name + " " + shopItems[i].cost + "$";
            }
            
        }
        
        
    }

    public void Update()
    {
        countUpgrades[0].text = "+" + PlayerPrefs.GetInt("Health").ToString();
        countUpgrades[1].text = "+" + PlayerPrefs.GetFloat("Speed") * 100 + "%";
        countUpgrades[2].text = "+" + PlayerPrefs.GetInt("Damage").ToString();
        countUpgrades[3].text = "+" + PlayerPrefs.GetInt("Armour").ToString() + "%";
        if (PlayerPrefs.GetInt("Moneys") < 0)
        {
            PlayerPrefs.SetInt("Moneys", 0);
        }
        for (int i = 0; i < shopItems.Count; i++)
        {
            if (shopItems[0].levelOfItem < 5) // Health
            {
                shopItemsText[i].text = shopItems[i].name + " " + shopItems[i].cost + "$";
            }

            if (shopItems[0].levelOfItem >= 5) 
            {
                shopBttns[0].interactable = false;
                shopItemsText[0].text = "Health is MAX.level";
            }
            if(shopItems[1].levelOfItem == 0) // Speed
            {
                shopItemsText[i].text = shopItems[i].name + " " + shopItems[i].cost + "$";
            }
            if (shopItems[1].levelOfItem == 2)
            {
                shopBttns[1].interactable = false;
                shopItemsText[1].text = "Speed is Max.Level";
            }

            if (shopItems[2].levelOfItem < 5) // Damage
            {

                shopItemsText[i].text = shopItems[i].name + " " + shopItems[i].cost + "$";
            }

            if (shopItems[2].levelOfItem >= 4)
            {
                shopBttns[2].interactable = false;
                shopItemsText[2].text = "Damage is Max.Level";
            } 
            if (shopItems[3].levelOfItem < 4) // Armour
            {

                shopItemsText[3].text = shopItems[3].name + " " + shopItems[3].cost + "$";
            }

            if (shopItems[3].levelOfItem >= 4)
            {
                shopBttns[3].interactable = false;
                shopItemsText[3].text = "Armour is Max.Level";
            }

        }

    }

    private void updateCosts()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            shopItemsText[i].text = shopItems[i].name + " " + shopItems[i].cost + "$";
        }
    }

    public void Save()
    {
        
        sv.levelOfItem = new int[shopItems.Count];
        sv.cost = new int[shopItems.Count];
        for (int i = 0; i < shopItems.Count; i++)
        {
            sv.levelOfItem[i] = shopItems[i].levelOfItem;
            sv.cost[i] = shopItems[i].cost;
            
        }
        PlayerPrefs.SetString("SV", JsonUtility.ToJson(sv));
        PlayerPrefs.Save();
    }

    public void BuyBttn(int index) //Метод при нажатии на кнопку покупки товара (индекс товара)
    {
        if (PlayerPrefs.GetInt("Moneys") >= shopItems[index].cost)
        {
            if (index == 0) // health
            {


                if (shopItems[0].levelOfItem == 0)
                {
                    shopItems[0].levelOfItem += 2;
                }
                else
                {
                    shopItems[0].levelOfItem++;
                }
                PlayerPrefs.SetInt("Moneys", PlayerPrefs.GetInt("Moneys") - shopItems[0].cost);
                shopItems[0].value += shopItems[0].valueMultiply * shopItems[0].levelOfItem;
                shopItems[0].cost *= shopItems[0].levelOfItem;
                PlayerPrefs.SetInt("Health", shopItems[0].value);
                Save();
            }






            if (index == 1) // speed
            {



                shopItems[1].levelOfItem += 2;

                PlayerPrefs.SetInt("Moneys", PlayerPrefs.GetInt("Moneys") - shopItems[1].cost);
                shopItems[1].valueSpeed *= shopItems[1].levelOfItem;
                shopItems[1].cost *= shopItems[1].levelOfItem;


                PlayerPrefs.SetFloat("Speed", shopItems[1].valueSpeed);
                Save();

            }
            if (index == 2) // damage
            {


                
                shopItems[2].levelOfItem++;
                
                PlayerPrefs.SetInt("Moneys", PlayerPrefs.GetInt("Moneys") - shopItems[2].cost);
                shopItems[2].value = shopItems[2].valueMultiply * shopItems[2].levelOfItem;
                shopItems[2].cost *= shopItems[2].levelOfItem;


                PlayerPrefs.SetInt("Damage", shopItems[2].value);
                Save();

            }
            if (index == 3) // Armour
            {


                if (shopItems[3].levelOfItem == 0)
                {
                    shopItems[3].levelOfItem += 2;
                }
                else
                {
                    shopItems[3].levelOfItem++;
                }
                PlayerPrefs.SetInt("Moneys", PlayerPrefs.GetInt("Moneys") - shopItems[3].cost);
                shopItems[3].value *= shopItems[3].levelOfItem;
                shopItems[3].cost *= shopItems[3].levelOfItem;
                PlayerPrefs.SetInt("Armour", shopItems[3].value);
                Save();
            }
        }
    }            
}
