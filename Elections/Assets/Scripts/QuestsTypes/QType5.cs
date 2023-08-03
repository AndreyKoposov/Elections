using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class QType5 : Quest
{
    public ResTypes _resToIncrease;
    public ResTypes _resToDecrease;
    public int _resDown;
    public int _resUp;
    public const TYPES TYPE = TYPES.TYPE5;

    public QType5(Fractions fraction) : base(fraction)
    {
        Random random = new Random();
        _resDown = random.Next(13, 19);
        _rateUp = random.Next(5, 10);
        _resUp = random.Next(9, 14);
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _resToIncrease = _info._resources.First();
        _resToDecrease = _info._resources.Last();

        this._taskAcception += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp;
            ResourceContainer resourceToIncrease = GetResourceByEnumFromGroup(_resToIncrease, res);
            resourceToIncrease.Value += _resUp;
            ResourceContainer resourceToDecrease = GetResourceByEnumFromGroup(_resToDecrease, res);
            resourceToDecrease.Value -= _resDown;
        };

        this._taskDeviation += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateUp;
            ResourceContainer resourceToIncrease = GetResourceByEnumFromGroup(_resToIncrease, res);
            resourceToIncrease.Value -= _resUp;
            ResourceContainer resourceToDecrease = GetResourceByEnumFromGroup(_resToDecrease, res);
            resourceToDecrease.Value += _resDown;
        };
    }
}
