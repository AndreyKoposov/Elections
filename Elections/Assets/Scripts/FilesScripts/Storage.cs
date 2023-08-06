using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.IO;

public class Storage : FileController, IFileWorker
{
    public Storage() : base()
    {
        SavePath = Application.persistentDataPath + "/saves/GameSave.save";
    }
}
