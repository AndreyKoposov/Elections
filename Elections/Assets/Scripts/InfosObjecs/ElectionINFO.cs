using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ElectionINFO
{
    public string _text;
    public string _answerText;
    public bool _win;
    public bool _isElection;
    public CenterButtonAction _ButtonClick;

    public ElectionINFO(Dictionary<Fractions, Fraction> group, bool gameOver)
    {
        _text = GetInfoHeader();
        _win = !gameOver;
        _answerText = GetAnswerText(gameOver);

        _text += GetInfoFooter(gameOver);

        _isElection = true;

        InitButtonClick();
    }

    public ElectionINFO()
    {
        _win = true;
        _text = "";
        _answerText = "";
        _isElection = false;

        InitButtonClick();
    }
    private void InitButtonClick() 
    {
        if(!_win)
            _ButtonClick = () =>
            {
                PanelController.Instance.EndGame();
                FractionGroup.ResetVotes();
            };
        else
            _ButtonClick = () => 
            {
                FractionGroup.ResetVotes();
                PanelController.Instance.graphic.gameObject.SetActive(false);
                PanelController.Instance.HidePanelImage();

                GameController.SaveGame();
            };
    }

    private string GetInfoHeader()
    {
        return "ВЫБОРЫ\nРезультаты голосования:\n\n\n\n";
    }

    private string GetInfoFooter(bool gameOver)
    {
        if (gameOver)
        {
            return "\nВы Проиграли и отстранены.";
        }
        else
        {
            return "\nВы Победили !!!";
        }
    }

    private string GetAnswerText(bool gameOver)
    {
        if (gameOver)
        {
            return "...";
        }
        else
        {
            return "Отлично";
        }
    }
}
