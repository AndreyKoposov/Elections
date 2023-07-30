using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : ScriptableObject
{
    public const string SAVE_PATH = "D:/";
    private const int START_VALUE = 0;
    private const int VALUE_TO_DECREASE = 6;
    private int _currentTurn;
    private TurnINFO _info;
    private bool _userMadeTurn;
    private bool _gameOver;
    private ElectionINFO _electionInfo;
    private Fractions? _whoWasAskeed;
    private GameOverINFO _gameOverInfo;
    private Dictionary<ResTypes, int> _valuePerTurn;
}
