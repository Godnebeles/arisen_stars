using System.IO;
using UnityEngine;

public class SaveStorage
{
    private string _filePath;

    public SaveStorage(string filePath)
    {
        _filePath = filePath;
    }

    public void Save(object dataForSave, string fileName)
    {
        if (!Directory.Exists(_filePath))
            Directory.CreateDirectory(_filePath);

        // using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(_filePath + fileName)))
        // {
        //     binaryWriter.Write(JsonUtility.ToJson(dataForSave));
        // }
        using (StreamWriter writer = new StreamWriter(_filePath + fileName, false))
        {
            writer.Write(JsonUtility.ToJson(dataForSave));
        }
    }

    public object Load(string fileName)
    {
        if (!File.Exists(fileName))
            return null;

        using (BinaryReader binaryReader = new BinaryReader(File.OpenRead(_filePath + fileName)))
        {
            string save = "";

            while (binaryReader.PeekChar() > -1)
            {
                save += binaryReader.ReadString();
            }

            return JsonUtility.FromJson(save, typeof(PlayerInfo));
        }
    }
}