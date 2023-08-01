using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnLabel : MonoBehaviour
{
    private int Turn = 1;
    [SerializeField] private TextMeshProUGUI text;

    private void FixedUpdate()
    {
        ChangeTurn(GameController.Game.CurrentTurn);
        SetText();
    }

    public void ChangeTurn(int turn)
    {
        Turn = turn;
        SetText();
    }

    private void SetText()
    {
        text.text = Turn.ToString();
    }

    
}
