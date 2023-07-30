using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnumConverter
{
    public static string ToString(ResTypes type)
    {
        switch (type)
        {
            case ResTypes.FOOD:
                return "Продовольствие";
            case ResTypes.METAL:
                return "Сырьё";
            case ResTypes.POWER:
                return "Мощь";
            case ResTypes.MONEY:
                return "Бюджет";
            default:
                return "";
        }
    }

    public static string ToString(Fractions fraction)
    {
        switch (fraction)
        {
            case Fractions.OLIGARCH:
                return "Олигархи";
            case Fractions.PEOPLE:
                return "Народ";
            case Fractions.WARRIOR:
                return "Военные";
            case Fractions.MAFIA:
                return "Мафия";
            default:
                return "";
        }
    }
}
