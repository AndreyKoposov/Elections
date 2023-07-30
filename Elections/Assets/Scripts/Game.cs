using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
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

    public Game()
    {
        _currentTurn = 1;
        _info = new TurnINFO(_currentTurn);
        _userMadeTurn = false;
        _whoWasAskeed = null;
        _gameOver = false;
        _electionInfo = new ElectionINFO();
        _gameOverInfo = null;
        _valuePerTurn = InitDictOfValues();

        InitAllData();
    }

    private Dictionary<ResTypes, int> InitDictOfValues()
    {
        Dictionary<ResTypes, int> dict = new Dictionary<ResTypes, int>();
        dict.Add(ResTypes.MONEY, START_VALUE);
        dict.Add(ResTypes.FOOD, START_VALUE);
        dict.Add(ResTypes.POWER, START_VALUE);
        dict.Add(ResTypes.METAL, START_VALUE);
        return dict;
    }

    public void InitAllData()
    {
        DataContainer.InitAllData();
        Oligarch.InitQuests();
        People.InitQuests();
        Mafia.InitQuests();
        Warrior.InitQuests();
        Mafia.InitHelpInfo();
        Oligarch.InitHelpInfo();
        People.InitHelpInfo();
        Warrior.InitHelpInfo();
        //Logger.InitLogFile();
    }
}
