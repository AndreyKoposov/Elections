using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FractionSerializable
{
    private int _rate;
    private bool exclamationMark;

    public FractionSerializable(Fraction fraction)
    {
        _rate = fraction.Rate;
        exclamationMark = fraction.Exclamation;
    }

    public void Load(Fraction fraction)
    {
        fraction.Rate = _rate;
        if (exclamationMark)
        {
            fraction.SetMark();
        }
    }
}
