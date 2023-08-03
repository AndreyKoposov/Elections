using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ResourceSerializable
{
    private int _value;
    private bool greenArrow;
    private bool redArrow;

    public ResourceSerializable(ResourceContainer res)
    {
        _value = res.Value;
        greenArrow = res.GreenArrow;
        redArrow = res.RedArrow;
    }

    public void Load(ResourceContainer res)
    {
        if(greenArrow)
            res.SetGreenArrow();
        if(redArrow)
            res.SetRedArrow();
        res.Value = _value;
    }
}
