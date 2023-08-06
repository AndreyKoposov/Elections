using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStorage : FileController
{
    public TurnStorage() : base()
    {
        SavePath = Application.persistentDataPath + "/saves/TurnRecord.save";
    }
}
