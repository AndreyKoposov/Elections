using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;

public class FileController : IFileWorker
{
    protected string SavePath;
    protected BinaryFormatter formatter;

    public FileController()
    {
        InitDirectory();

        InitFormatter();
    }

    protected void InitDirectory()
    {
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
    }

    protected void InitFormatter()
    {
        formatter = new BinaryFormatter();
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogError("Doesnt exist");
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }

        var file = File.Open(SavePath, FileMode.Open);
        object savedData = formatter.Deserialize(file);

        if (savedData == null)
        {
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }
        file.Close();
        return savedData;
    }

    public void Save(object data)
    {
        var file = File.Create(SavePath);
        formatter.Serialize(file, data);
        file.Close();
    }

    public void Delete()
    {
        File.Delete(SavePath);
    }
}
