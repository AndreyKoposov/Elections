using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : Fraction
{
    private const Fractions TYPE = Fractions.PEOPLE;



    public override Fractions Type
    {
        get { return TYPE; }
    }
}
