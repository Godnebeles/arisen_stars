using System.IO;
using UnityEngine;

public class SaveStorage
{
    private PlayerDataDTO _saveData;
    private readonly string _filePath = Application.persistentDataPath + "/saves/";
    private readonly string _fileName = "player_save.save";

    public void Save(PlayerDataDTO playerDataDTO)
    {
        if (!Directory.Exists(_filePath))
            Directory.CreateDirectory(_filePath);

        using (StreamWriter writer = new StreamWriter(File.Create(_filePath + _fileName)))
        {
            writer.Write(JsonUtility.ToJson(playerDataDTO));
        }
    }

    public PlayerDataDTO Load()
    {
        if (!File.Exists(_filePath + _fileName))
            return null;
        
        using (StreamReader reader = new StreamReader(File.OpenRead(_filePath + _fileName)))
        {
            string jsonString = reader.ReadToEnd();

            return JsonUtility.FromJson<PlayerDataDTO>(jsonString);
        }
    }
}