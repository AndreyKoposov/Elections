using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsStorage : FileController
{
    public SettingsStorage() : base()
    {
        SavePath = Application.persistentDataPath + "/saves/Settings.save";
    }
}
