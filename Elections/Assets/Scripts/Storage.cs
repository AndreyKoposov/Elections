using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;

public class Storage
{
    private string SavePath = Application.persistentDataPath + "/saves/GameSave.save";
    private BinaryFormatter formatter;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        InitFormatter();
    }

    private void InitFormatter()
    {
        formatter = new BinaryFormatter();
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(SavePath))
        {
            if (saveDataByDefault != null){
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }

        var file = File.Open(SavePath, FileMode.Open);
        object savedData = formatter.Deserialize(file);
        file.Close();
        return savedData;
    }

    public void Save(object data)
    {
        var file =  File.Create(SavePath);
        formatter.Serialize(file, data);
        file.Close();
    }

    public void Delete()
    {
        File.Delete(SavePath);
    }
}
