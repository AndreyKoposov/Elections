using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class QType6 : Quest
{
    public Fractions _anotherFraction;
    public Fractions _secondFraction;
    public int _rateDown;
    public const TYPES TYPE = TYPES.TYPE6;

    public QType6(Fractions fraction) : base(fraction)
    {
        Random random = new Random();
        _rateDown = random.Next(7, 11);
        _rateUp = random.Next(20, 30);
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _anotherFraction = _info._fractions.First();
        _secondFraction = _info._fractions.Last();

        this._taskAcception = (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate -= _rateDown;
            Fraction secondFractionObj = GetFractionByEnumFromGroup(_secondFraction, group);
            secondFractionObj.Rate -= _rateDown;
        };

        this._taskDeviation = (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate += _rateDown;
            Fraction secondFractionObj = GetFractionByEnumFromGroup(_secondFraction, group);
            secondFractionObj.Rate += _rateDown;
        };
    }
}
