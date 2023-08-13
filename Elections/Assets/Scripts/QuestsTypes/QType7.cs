using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;

public class QType7 : Quest
{
    public ResTypes _resToDecrease;
    public int _resDown;
    public const TYPES TYPE = TYPES.TYPE7;

    public QType7(Fractions fraction) : base(fraction)
    {
        Random random = new Random();
        _resDown = random.Next(10, 17);
        _info = GetQuestInfoByFraction(_whichQuest, TYPE);
        _resToDecrease = _info._resources.First();

        this._taskAcception += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate += _rateUp;
            MainFractionObj.voteBar.SetForLast(1);
            ResourceContainer resourceToIncrease = GetResourceByEnumFromGroup(_resToDecrease, res);
            resourceToIncrease.Value -= _resDown;
        };

        this._taskDeviation += (group, res) =>
        {
            Fraction MainFractionObj = GetFractionByEnumFromGroup(_whichQuest, group);
            MainFractionObj.Rate -= _rateUp;
            MainFractionObj.voteBar.SetAgainstLast(1);
            ResourceContainer resourceToIncrease = GetResourceByEnumFromGroup(_resToDecrease, res);
            resourceToIncrease.Value += _resDown;
        };
    }
}
