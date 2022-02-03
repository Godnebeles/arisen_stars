using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMenuButton : MonoBehaviour
{
    public GameObject menuShopPanel;
    public GameObject upgradePanen;
    public GameObject settingsPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Проверка на нажатие кнопки "назад" на телефоне
        {
            if (menuShopPanel.activeSelf)
            {
                menuShopPanel.SetActive(false);
            }
            if (!menuShopPanel.activeSelf || !settingsPanel.activeSelf)
            {
                Application.Quit();
            }
            if (settingsPanel.activeSelf)
            {
                settingsPanel.SetActive(false);
            }
        }

    }
}
