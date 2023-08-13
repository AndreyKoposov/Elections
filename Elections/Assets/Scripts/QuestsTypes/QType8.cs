using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QType8 : Quest
{
    public Fractions _fractionToIncrease_2;
    public Fractions _fractionToDecrease_1;
    public Fractions _fractionToDecrease_2;
    public const TYPES TYPE = TYPES.TYPE8;

    public QType8(Fractions fraction) : base(fraction)
    {
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _fractionToIncrease_2 = _info._fractions.First();
        _fractionToDecrease_1 = _info._fractions[1];
        _fractionToDecrease_2 = _info._fractions.Last();

        this._taskAcception += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp + 4;
            MainFractionObj.voteBar.SetForLast(1);
            Fraction FractionToIncrease_2 = GetFractionByEnumFromGroup(_fractionToIncrease_2, group);
            FractionToIncrease_2.Rate += _rateUp + 4;
            FractionToIncrease_2.voteBar.SetForLast(1);
            Fraction FractionToDecrease_1 = GetFractionByEnumFromGroup(_fractionToDecrease_1, group);
            FractionToDecrease_1.Rate -= _rateUp + 4;
            FractionToDecrease_1.voteBar.SetAgainstLast(1);
            Fraction FractionToDecrease_2 = GetFractionByEnumFromGroup(_fractionToDecrease_2, group);
            FractionToDecrease_2.Rate -= _rateUp + 4;
            FractionToDecrease_2.voteBar.SetAgainstLast(1);
        };

        this._taskDeviation += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateUp + 4;
            MainFractionObj.voteBar.SetAgainstLast(1);
            Fraction FractionToIncrease_2 = GetFractionByEnumFromGroup(_fractionToIncrease_2, group);
            FractionToIncrease_2.Rate -= _rateUp + 4;
            FractionToIncrease_2.voteBar.SetAgainstLast(1);
            Fraction FractionToDecrease_1 = GetFractionByEnumFromGroup(_fractionToDecrease_1, group);
            FractionToDecrease_1.Rate += _rateUp + 4;
            FractionToDecrease_1.voteBar.SetForLast(1);
            Fraction FractionToDecrease_2 = GetFractionByEnumFromGroup(_fractionToDecrease_2, group);
            FractionToDecrease_2.Rate += _rateUp + 4;
            FractionToDecrease_2.voteBar.SetForLast(1);
        };
    }
}
