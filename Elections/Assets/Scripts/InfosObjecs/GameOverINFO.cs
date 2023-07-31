using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverINFO
{
    public string _text;
    public string _answer;
    public ResTypes _reason;

    public GameOverINFO(ResTypes reason)
    {
        _reason = reason;
        _answer = "...";
        _text = GetTextByResType(_reason);
    }

    private string GetTextByResType(ResTypes reason)
    {
        switch (reason)
        {
            case ResTypes.FOOD:
                return DataContainer.GameOverTexts[Fractions.PEOPLE];
            case ResTypes.METAL:
                return DataContainer.GameOverTexts[Fractions.MAFIA];
            case ResTypes.POWER:
                return DataContainer.GameOverTexts[Fractions.WARRIOR];
            case ResTypes.MONEY:
                return DataContainer.GameOverTexts[Fractions.OLIGARCH];
            default:
                return "";
        }
    }
}
