using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStorageController : MonoBehaviour
{
    private SaveStorage _saveStorage;
    private void Start()
    {
        _saveStorage = new SaveStorage(Application.persistentDataPath + "/saves/");
        
        _saveStorage.Save(new PlayerInfo(),"json_save.json");
        
        // PlayerInfo playerInfo = (PlayerInfo) _saveStorage.Load("player_save.save");
        //
        // Debug.Log(playerInfo.damage);
    }

    private void Update()
    {
        
    }
}
