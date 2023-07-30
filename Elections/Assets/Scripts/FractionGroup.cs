using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractionGroup : MonoBehaviour
{
    private Dictionary<Fractions, Fraction> fractions;

    private void Awake()
    {
        fractions = new Dictionary<Fractions, Fraction>();
        Fraction[] frac = GetComponentsInChildren<Fraction>();
        foreach (Fraction f in frac)
        {
            fractions.Add(f.Type, f);
        }
    }

    void Start()
    {
        DeselectAll();
    }

    public void DeselectAll()
    {
        foreach (Fraction fraction in fractions.Values)
        {
            fraction.Deselect();
        }
    }

    public Fraction this[Fractions fraction]
    {
        get
        {
            return fractions[fraction];
        }
    }

    public Fraction GetLowestRateFractionExceptOne(Fractions whichQuestFraction)
    {
        List<Fraction> rates = FractionsRatesToList();
        List<Fraction> sortRates = SortFractionList(rates);

        if (sortRates[0].Type == whichQuestFraction)
        {
            return sortRates[1];
        }
        return sortRates[0];
    }

    private List<Fraction> FractionsRatesToList()
    {
        List<Fraction> rates = new List<Fraction>(fractions.Values);
        return rates;
    }

    private List<Fraction> SortFractionList(List<Fraction> rates)
    {
        rates.Sort(Fraction.CompareFraction);
        return rates;
    }
}
