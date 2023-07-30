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
                return "��������������";
            case ResTypes.METAL:
                return "�����";
            case ResTypes.POWER:
                return "����";
            case ResTypes.MONEY:
                return "������";
            default:
                return "";
        }
    }

    public static string ToString(Fractions fraction)
    {
        switch (fraction)
        {
            case Fractions.OLIGARCH:
                return "��������";
            case Fractions.PEOPLE:
                return "�����";
            case Fractions.WARRIOR:
                return "�������";
            case Fractions.MAFIA:
                return "�����";
            default:
                return "";
        }
    }
}
