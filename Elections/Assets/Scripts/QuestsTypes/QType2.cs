using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class QType2 : Quest
{
    public Fractions _anotherFraction;
    public ResTypes _resToIncrease;
    public int _rateDown;
    public int _resUp;
    public const TYPES TYPE = TYPES.TYPE2;

    public QType2(Fractions fraction) : base(fraction)
    {
        Random random = new Random();
        _rateDown = random.Next(12, 20);
        _rateUp = random.Next(5, 10);
        _resUp = random.Next(8, 15);
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _anotherFraction = _info._fractions.First();
        _resToIncrease = _info._resources.First();

        this._taskAcception = (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate -= _rateDown;
            ResourceContainer resourceToIncrease = GetResourceByEnumFromGroup(_resToIncrease, res);
            resourceToIncrease.Value += _resUp;
        };

        this._taskDeviation = (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate += _rateUp;
        };
    }
}
