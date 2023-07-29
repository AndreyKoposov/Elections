using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractionGruopController : MonoBehaviour
{
    private Fraction[] fractions;

    private void Awake()
    {
        fractions = GetComponentsInChildren<Fraction>();
    }

    void Start()
    {
        DeselectAll();
    }

    public void DeselectAll()
    {
        for (int i = 0; i < fractions.Length; i++)
        {
            fractions[i].Deselect();
        }
    }
}
