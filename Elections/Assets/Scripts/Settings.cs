using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Settings
{
    private bool isSound;

    public Settings()
    {
        isSound = true;
    }

    public bool Sound
    {
        get { return isSound; }
        set { isSound = value; }
    }
}
