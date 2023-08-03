using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class QType4 : Quest
{
    public Fractions _anotherFraction;
    public Fractions _fractionToDecrease;
    public ResTypes _resToDecrease;
    public int _rateDown;
    public int _secondRateUp;
    public int _resDown;
    public const TYPES TYPE = TYPES.TYPE4;

    public QType4(Fractions fraction) : base(fraction)
    {
        Random random = new Random();
        _rateDown = random.Next(5, 11);
        _rateUp = random.Next(5, 11);
        _secondRateUp = random.Next(5, 11);
        _resDown = random.Next(8, 15);
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _anotherFraction = _info._fractions.First();
        _fractionToDecrease = _info._fractions.Last();
        _resToDecrease = _info._resources.First();

        this._taskAcception += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate += _secondRateUp;
            Fraction SecondFractionObj = GetFractionByEnumFromGroup(_fractionToDecrease, group);
            SecondFractionObj.Rate -= _rateDown;
            SecondFractionObj.voteBar.SetAgainstLast(1);
            ResourceContainer resourceToDecrease = GetResourceByEnumFromGroup(_resToDecrease, res);
            resourceToDecrease.Value -= _resDown;
        };

        this._taskDeviation += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate -= _rateDown;
            Fraction SecondFractionObj = GetFractionByEnumFromGroup(_fractionToDecrease, group);
            SecondFractionObj.Rate += _rateUp + 6;
            SecondFractionObj.voteBar.SetForLast(1);
        };
    }
}
