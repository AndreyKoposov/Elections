using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class QType3 : Quest
{
    public Fractions _anotherFraction;
    public ResTypes _resToIncrease;
    public ResTypes _resToDecrease;
    public int _rateDown;
    public int _resUp;
    public int _resDown;
    public const TYPES TYPE = TYPES.TYPE3;

    public QType3(Fractions fraction) : base(fraction)
    {
        Random random = new Random();
        _rateDown = random.Next(5, 11);
        _rateUp = random.Next(5, 11);
        _resUp = random.Next(8, 15);
        _resDown = random.Next(8, 15);
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _anotherFraction = _info._fractions.First();
        _resToIncrease = _info._resources.First();
        _resToDecrease = _info._resources.Last();

        this._taskAcception = (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate -= _rateDown;
            ResourceContainer resourceToIncrease = GetResourceByEnumFromGroup(_resToIncrease, res);
            resourceToIncrease.Value += _resUp;
            ResourceContainer resourceToDecrease = GetResourceByEnumFromGroup(_resToDecrease, res);
            resourceToDecrease.Value -= _resDown;
        };

        this._taskDeviation = (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateUp;
            Fraction AnotherFractionObj = GetFractionByEnumFromGroup(_anotherFraction, group);
            AnotherFractionObj.Rate += _rateDown;
        };
    }
}
