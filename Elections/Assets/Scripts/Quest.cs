using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public delegate void ActionPerform(FractionGroup group, ResourceGroup resources);

public class Quest
{
    public QuestINFO _info;
    public Fractions _whichQuest;
    public int _rateUp;
    public ActionPerform _taskAcception;
    public ActionPerform _taskDeviation;

    public Quest(Fractions fraction)
    {
        _whichQuest = fraction;
    }

    protected Fraction GetFractionByEnumFromGroup(Fractions fraction, FractionGroup group)
    {
        return group[fraction];
    }

    protected ResourceContainer GetResourceByEnumFromGroup(ResTypes type, ResourceGroup resGroup)
    {
        return resGroup[type];
    }

    protected QuestINFO GetQuestInfoByFraction(Fractions fraction, TYPES TYPE)
    {
        QuestINFO info;
        /*switch (fraction)
        {
            case Fractions.OLIGARCH:
                info = GetRandomQuestInfo(Oligarch.Quests, TYPE);
                return info;
            case Fractions.PEOPLE:
                info = GetRandomQuestInfo(People.Quests, TYPE);
                return info;
            case Fractions.WARRIOR:
                info = GetRandomQuestInfo(Warrior.Quests, TYPE);
                return info;
            case Fractions.MAFIA:
                info = GetRandomQuestInfo(Mafia.Quests, TYPE);
                return info;
            default:
                return null;
        }*/
        return null;
    }

    protected QuestINFO GetRandomQuestInfo(List<QuestINFO> list, TYPES TYPE)
    {
        Random random = new Random();
        int randIndex = random.Next(0, list.Count);
        QuestINFO info = list[randIndex];
        while (info._type != TYPE)
        {
            randIndex = random.Next(0, list.Count);
            info = list[randIndex];
        }
        info = ReplaceRandomInserts(info);
        return info;
    }

    private QuestINFO ReplaceRandomInserts(QuestINFO info)
    {
        string text = info._text;
        /*text = text.Replace("_C_", DataContainer.RandomColonie);
        text = text.Replace("_N_", DataContainer.RandomName);
        text = text.Replace("_P_", DataContainer.RandomPlanet);
        text = text.Replace("_S_", DataContainer.RandomSystem);
        text = text.Replace("_I_", DataContainer.RandomImperia);*/
        info._text = text;
        return info;
    }
}
