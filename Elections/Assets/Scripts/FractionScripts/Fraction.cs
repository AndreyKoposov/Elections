using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Random = System.Random;

public enum Fractions
{
    OLIGARCH, PEOPLE, MAFIA, WARRIOR
}

public class Fraction : MonoBehaviour
{
    public const int MAX_RATE = 100;
    public const int MIN_RATE = 0;
    public GameButton _quest;
    public GameButton _help;
    public SelectableIcon _background;
    public SelectableIcon _image;
    private Button _imageButton;
    public MoveableImage TopImage;
    public Rate rateBar;

    protected int _rate;

    public int Rate
    {
        get { return _rate; }
        set
        {
            int buffer = _rate;
            _rate = value;
            if (_rate > MAX_RATE)
                _rate = MAX_RATE;
            if (_rate < MIN_RATE)
                _rate = MIN_RATE;
            int diff = value - buffer;
            rateBar.SetRate(_rate);
        }
    }

    public int Vote
    {
        get
        {
            if (_rate <= 25)
                return -1;
            if (_rate >= 75)
                return 1;
            else
                return 0;
        }
    }
    public virtual Fractions Type
    {
        get;
    }
    public virtual ResTypes TypeRes
    {
        get;
    }

    private void Awake()
    {
        _imageButton = _image.gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        Rate = 50;
    }

    public void Select()
    {
        _background.Select();
        _image.Select();
        _quest.Show();
        _help.Show();
    }

    public void Deselect()
    {
        _background.Deselect();
        _image.Deselect();
        _quest.Hide();
        _help.Hide();
    }

    public static int CompareFraction(Fraction x, Fraction y)
    {
        return x.Rate.CompareTo(y.Rate);
    }

    public virtual void MoveTopImageToCenter()
    {
        LeanTween.moveLocal(TopImage.gameObject, new Vector3(0, -30, 0), 0.4f);
        LeanTween.scale(TopImage.gameObject, new Vector3(1.6f, 1.6f, 1.6f), 0.4f);
    }
    public virtual void MoveTopImageToPanel()
    {
        LeanTween.moveLocal(TopImage.gameObject, new Vector3(0, 290, 0), 0.2f);
        LeanTween.scale(TopImage.gameObject, new Vector3(0.6f, 0.6f, 0.6f), 0.2f);
    }

    private IEnumerator Animation()
    {
        DarkController.Instance.MakeDark();
        MoveTopImageToCenter();

        yield return new WaitForSeconds(0.4f);

        PanelController.Instance.SetChooseMode();
        PanelController.Instance.MoveToCenter();

        yield return new WaitForSeconds(0.5f);

        DarkController.Instance.ResetDark();
        MoveTopImageToPanel();
    }

    public void StartQuest()
    {
        Deselect();
        SetupTopImage();
        StartCoroutine(Animation());

        GameController.Game.UserMadeTurn = true;
        GameController.Game.WhoWasAsked = Type;

        Quest quest = GetRandomQuest();

        PanelController panel = PanelController.Instance;
        SetUpPanel(panel, quest);
    }

    private void SetupTopImage()
    {
        TopImage.gameObject.SetActive(true);
        PanelController.Instance.InfoIamge = TopImage;
    }

    private Quest GetRandomQuest()
    {
        Random random = new Random();
        TYPES rType = (TYPES)random.Next(0, 6);
        switch (rType)
        {
            case TYPES.TYPE1:
                return new QType1(Type);
            case TYPES.TYPE2:
                return new QType2(Type);
            case TYPES.TYPE3:
                return new QType3(Type);
            case TYPES.TYPE4:
                return new QType4(Type);
            case TYPES.TYPE5:
                return new QType5(Type);
            case TYPES.TYPE6:
                return new QType6(Type);
            default:
                return new QType1(Type);
        }
    }

    public void StartHelp()
    {
        Deselect();
        SetupTopImage();
        StartCoroutine(Animation());

        GameController.Game.UserMadeTurn = true;
        GameController.Game.WhoWasAsked = Type;

        FractionHelp help = FractionGroup.Group[Type].GetHelp();

        Fractions lowRateFraction = FractionGroup.GetLowestRateFractionExceptOne(help._whichHelp.Type).Type;
        ResTypes lowValueResource = ResourceGroup.GetLowestValueResourceExceptOne(help._whichHelp.TypeRes).Type;
        help.InsertInTextFractionName(lowRateFraction);
        help.InsertInTexResourceName(lowValueResource);

        PanelController panel = PanelController.Instance;
        SetUpPanel(panel, help);
    }

    private void SetUpPanel(PanelController panel, Quest quest)
    {
        panel.SetText(quest._info._text);
        panel.SetLeftButtonText(quest._info._yesAnswer);
        panel.SetRightButtonText(quest._info._noAnswer);
        panel.Left = quest._taskAcception;
        panel.Right = quest._taskDeviation;
    }

    private void SetUpPanel(PanelController panel, FractionHelp help)
    {
        panel.SetText(help._info._text);
        panel.SetLeftButtonText(help._info._yesAnswer);
        panel.SetRightButtonText(help._info._noAnswer);
        panel.Left = help._leftChoose;
        panel.Right = help._rightChoose;
    }

    protected virtual FractionHelp GetHelp()
    {
        return null;
    }

    public void OnInteractive()
    {
        _imageButton.interactable = true;
    }
    public void OffInteractive()
    {
        _imageButton.interactable = false;
    }
}
