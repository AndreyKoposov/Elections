using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

[Serializable]
public class FractionSerializable
{
    private int _rate;
    private bool exclamationMark;
    private List<VoteState> votes;

    public FractionSerializable(Fraction fraction)
    {
        _rate = fraction.Rate;
        exclamationMark = fraction.Exclamation;
        votes = new List<VoteState>();

        for(int i = 0; i < fraction.voteBar.Lenght; i++)
        {
            votes.Add(fraction.voteBar[i]);
        }
    }

    public void Load(Fraction fraction)
    {
        fraction.Rate = _rate;
        if (exclamationMark)
        {
            fraction.SetMark();
        }

        fraction.voteBar.ResetAll();

        foreach(VoteState vote in votes)
        {
            if (vote == VoteState.None)
            {
                break;
            }
            if (vote == VoteState.For)
            {
                fraction.voteBar.SetForLast(1);
            }
            if (vote == VoteState.Against)
            {
                fraction.voteBar.SetAgainstLast(1);
            }
        }
    }
}
