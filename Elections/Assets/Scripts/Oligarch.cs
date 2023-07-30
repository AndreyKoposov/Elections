using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oligarch : Fraction
{
    private const Fractions TYPE = Fractions.OLIGARCH;


    public override Fractions Type
    {
        get { return TYPE; }
    }
}
