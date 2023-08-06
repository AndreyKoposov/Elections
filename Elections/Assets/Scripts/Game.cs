using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Game
{
    public const int TOTAL_VOTES = 24;
    public const int START_VALUE = 0;
    public const int VALUE_TO_DECREASE = 6;

    private int _currentTurn;
    private bool _userMadeTurn;
    private bool _gameOver;
    private ElectionINFO _electionInfo;
    private Fractions? _whoWasAskeed;
    private GameOverINFO _gameOverInfo;
    private Dictionary<ResTypes, int> _valuePerTurn;
    private int _forVotes;
    private SerializableContainer _serializableContianer;

    public Game()
    {
        _currentTurn = 1;
        _userMadeTurn = false;
        _whoWasAskeed = null;
        _gameOver = false;
        _electionInfo = new ElectionINFO();
        _gameOverInfo = null;
        _valuePerTurn = InitDictOfValues();
        _forVotes = 0;

        InitAllData();
    }

    public bool UserMadeTurn
    {
        get { return _userMadeTurn; }
        set { _userMadeTurn = value; }
    }

    public int CurrentTurn
    {
        get { return _currentTurn; }
        set { _currentTurn = value; }
    }

    public ElectionINFO ElectionInfo
    {
        get { return _electionInfo; }
    }

    public GameOverINFO GameOverInfo
    {
        get { return _gameOverInfo; }
    }

    public Fractions? WhoWasAsked
    {
        get { return _whoWasAskeed; }
        set { _whoWasAskeed = value; }
    }

    public SerializableContainer Container
    {
        get { return _serializableContianer; }
        set { _serializableContianer = value; }
    }

    public int MoneyChange
    {
        get { return _valuePerTurn[ResTypes.MONEY]; }
    }
    public int FoodChange
    {
        get { return _valuePerTurn[ResTypes.FOOD]; }
    }
    public int MetalChange
    {
        get { return _valuePerTurn[ResTypes.METAL]; }
    }
    public int PowerChange
    {
        get { return _valuePerTurn[ResTypes.POWER]; }
    }
    public string StartText
    {
        get { return DataContainer.StartText; }
    }

    public string LearnText
    {
        get { return DataContainer.LearnText; }
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

    public void NextTurn()
    {
        if (TryInitGameOverInfo())
        {
            _gameOver = true;
            PanelController.SetUpPanel(_gameOverInfo);
            PanelController.Instance.SetDefaultMode();
            PanelController.Instance.MoveToCenter(0);
            return;
        }

        if (isTurnOfElections() && !_gameOver)
        {
            FractionGroup.FillRemaining();
            
            _gameOver = !isUserWinElections();
            _electionInfo = new ElectionINFO(FractionGroup.Group, _gameOver);
            PanelController.SetUpPanel(_electionInfo);
            PanelController.Instance.SetDefaultMode();
            FractionGroup.OffInteractiveAll();
            PanelController.Instance.MoveToCenter(2f, _forVotes);
        }
        else
        {
            _electionInfo = new ElectionINFO();
        }

        _currentTurn++;
        _userMadeTurn = false;

        if (isTurnOfMarkingFraction())
        {
            FractionGroup.SetOneFractionMark();
        }
        else
        {
            FractionGroup.ResetAllMark();
        }

        FractionGroup.OnInteractiveAll();
        FractionGroup.OffInteractive(_whoWasAskeed);
        FractionGroup.SetAppendValues(_valuePerTurn);
        ResourceGroup.DecreaseRandomResource(VALUE_TO_DECREASE);
        ResourceGroup.AppendValuesToResources(_valuePerTurn);

        GameController.SaveGame();
        GameController.UpdateRecord(_currentTurn);
    }

    private bool TryInitGameOverInfo()
    {
        _gameOverInfo = ResourceGroup.GetGameOverInfo();
        if (_gameOverInfo == null)
            return false;
        return true;
    }
    private bool isTurnOfElections()
    {
        return _currentTurn % 10 == 0;
    }

    private bool isUserWinElections()
    {
        _forVotes = FractionGroup.CountVotes();
        if (_forVotes < TOTAL_VOTES / 2)
            return false;
        return true;
    }

    private bool isTurnOfMarkingFraction()
    {
        return Randomizer.GetRandom(0, 2) == 0;
    }
}
