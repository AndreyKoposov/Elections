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
        int sumOfVotes = fractions[Fractions.OLIGARCH].Votes
            + fractions[Fractions.PEOPLE].Votes
            + fractions[Fractions.WARRIOR].Votes
            + fractions[Fractions.MAFIA].Votes;
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

    public static void ResetVotes()
    {
        foreach(Fraction fraction in fractions.Values)
        {
            fraction.voteBar.ResetAll();
        }
    }

    public static void FillRemaining()
    {
        foreach(Fraction fraction in fractions.Values)
        {
            fraction.voteBar.FillReamaining(fraction.Rate);
        }
    }

    public static void SetOneFractionMark()
    {
        ResetAllMark();

        List<Fraction> selectoredList = new List<Fraction>();
        SelectFractions(selectoredList);
        if (isEmpty(selectoredList))
        {
            return;
        }
        
        Fraction markFraction = selectoredList[Randomizer.GetRandom(0, selectoredList.Count)];
        markFraction.SetMark();

    }

    public static void ResetAllMark()
    {
        foreach (Fraction fraction in fractions.Values)
        {
            fraction.ResetMark();
        }
    }

    private static void SelectFractions(List<Fraction> listWhereSelect)
    {
        foreach (var pair in fractions)
        {
            if(GameController.Game.WhoWasAsked != pair.Key && !pair.Value.voteBar.isFilled())
            {
                listWhereSelect.Add(pair.Value);
            }
        }
    }

    private static bool isEmpty(List<Fraction> list)
    {
        return list.Count == 0;
    }
}
