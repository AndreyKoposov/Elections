using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Fraction
{
    private const Fractions TYPE = Fractions.WARRIOR;



    public override Fractions Type
    {
        get { return TYPE; }
    }
}
