using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia : Fraction
{
    private const Fractions TYPE = Fractions.MAFIA;

    public override Fractions Type
    {
        get { return TYPE; }
    }
}
