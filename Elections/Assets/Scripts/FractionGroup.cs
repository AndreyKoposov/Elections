using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractionGroup : MonoBehaviour
{
    private static Dictionary<Fractions, Fraction> fractions;

    private void Awake()
    {
        fractions = new Dictionary<Fractions, Fraction>();
        Fraction[] frac = GetComponentsInChildren<Fraction>();
        foreach (Fraction f in frac)
        {
            fractions.Add(f.Type, f);
        }
    }

    public static Dictionary<Fractions, Fraction> Group
    {
        get { return fractions; }
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

    public static Fraction GetLowestRateFractionExceptOne(Fractions whichQuestFraction)
    {
        List<Fraction> rates = FractionsRatesToList();
        List<Fraction> sortRates = SortFractionList(rates);

        if (sortRates[0].Type == whichQuestFraction)
        {
            return sortRates[1];
        }
        return sortRates[0];
    }

    private static List<Fraction> FractionsRatesToList()
    {
        List<Fraction> rates = new List<Fraction>(fractions.Values);
        return rates;
    }

    private static List<Fraction> SortFractionList(List<Fraction> rates)
    {
        rates.Sort(Fraction.CompareFraction);
        return rates;
    }

    public static int CountVotes()
    {
        int sumOfVotes = fractions[Fractions.OLIGARCH].Vote
            + fractions[Fractions.PEOPLE].Vote
            + fractions[Fractions.WARRIOR].Vote
            + fractions[Fractions.MAFIA].Vote;
        return sumOfVotes;
    }

    public static void SetAppendValues(Dictionary<ResTypes, int> valuePerTurn)
    {
        foreach(Fraction fraction in fractions.Values)
        {
            SetResAppendByFraction(fraction, valuePerTurn);
        }
    }

    private static void SetResAppendByFraction(Fraction fraction, Dictionary<ResTypes, int> valuePerTurn)
    {
        if (fraction.Rate >= 75)
        {
            valuePerTurn[fraction.TypeRes] = 3;
            return;
        }
        if (fraction.Rate <= 25)
        {
            valuePerTurn[fraction.TypeRes] = -6;
        }
        else
        {
            valuePerTurn[fraction.TypeRes] = 0;
        }
    }

    public static void OnInteractiveAll()
    {
        foreach (Fraction f in fractions.Values)
        {
            f.OnInteractive();
        }
    }

    public static void OffInteractive(Fractions? fraction)
    {
        if (fraction == null)
            return;
        Fractions f = (Fractions)fraction;
        fractions[f].OffInteractive();
    }
    public static void OffInteractiveAll()
    {
        foreach (Fraction f in fractions.Values)
        {
            f.OffInteractive();
        }
    }
}
