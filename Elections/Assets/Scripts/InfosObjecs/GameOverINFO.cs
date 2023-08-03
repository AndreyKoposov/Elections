using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public delegate void CenterButtonAction();

[Serializable]
public class GameOverINFO
{
    public string _text;
    public string _answer;
    public ResTypes _reason;
    public CenterButtonAction _ButtonClick;

    public GameOverINFO(ResTypes reason)
    {
        _reason = reason;
        _answer = "...";
        _text = GetTextByResType(_reason);
        _ButtonClick = () =>
        {
            PanelController.Instance.EndGame();
        };
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
