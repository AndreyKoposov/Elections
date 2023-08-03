using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class QType1 : Quest
{
    public Fractions _anotherFraction;
    public int _rateDown;
    public const TYPES TYPE = TYPES.TYPE1;

    public QType1(Fractions fraction) : base(fraction)
    {
        Random random = new Random();
        _rateDown = random.Next(6, 12);
        _rateUp = random.Next(6, 11);
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _anotherFraction = _info._fractions.First();

        this._taskAcception += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp;
            MainFractionObj.voteBar.SetForLast(1);
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate -= _rateDown;
        };

        this._taskDeviation += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateDown;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate += _rateUp;
            AnotherFractionObj.voteBar.SetForLast(1);
        };
    }
}
