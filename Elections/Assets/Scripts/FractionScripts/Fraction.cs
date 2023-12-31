using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Random = System.Random;

[Serializable]
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
    public VoteBar voteBar;
    public Image redFlag;
    public Image greenFlag;
    public Image Mark;
    protected bool helpLocked = true;
    protected bool exclamationMark = false;
    private static Random random = new Random();

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
            SetFlag();
            SetHelp();
        }
    }

    public bool Exclamation
    {
        get { return exclamationMark; }
    }

    public int Votes
    {
        get { return voteBar.CountVotes(); }
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
        _rate = 50;
        LockHelp();
        _imageButton = _image.gameObject.GetComponent<Button>();
    }

    private void SetFlag()
    {
        if (Rate <= 25)
        {
            SetRedFlag();
            return;
        }
        if (Rate >= 75)
        {
            SetGreenFlag();
            return;
        }
        ResetFlags();
    }

    private void SetHelp()
    {
        if (Rate >= 75)
        {
            UnlockHelp();
        } else
            LockHelp();
    }

    private void Start()
    {
        Rate = _rate;
        voteBar.ResetAll();

        if((float)Screen.width / (float)Screen.height > 2)
        {
            _background.SetSmaller();
            _image.SetSmaller();
            if (Type == Fractions.MAFIA || Type == Fractions.WARRIOR)
            {
                RectTransform rt = GetComponent<RectTransform>();
                Vector2 temp = rt.localPosition;
                temp.y += 20;
                rt.localPosition = temp;
            }
        }
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
        LeanTween.moveLocal(TopImage.gameObject, new Vector3(0, 250, 0), 0.2f);
        LeanTween.scale(TopImage.gameObject, new Vector3(0.6f, 0.6f, 0.6f), 0.2f);
    }

    private IEnumerator Animation()
    {
        DarkController.Instance.MakeDark();
        MoveTopImageToCenter();

        yield return new WaitForSeconds(0.4f);

        PanelController.Instance.MoveToCenter(0);

        yield return new WaitForSeconds(0.5f);

        DarkController.Instance.ResetDark();
        MoveTopImageToPanel();
    }

    public void StartQuest()
    {
        FractionGroup.OffInteractiveAll();
        Deselect();
        SetupTopImage();
        PanelController.Instance.SetChooseMode();

        GameController.Game.UserMadeTurn = true;
        GameController.Game.WhoWasAsked = Type;

        Quest quest = GetRandomQuest();

        PanelController.SetUpPanel(quest);

        StartCoroutine(Animation());
    }

    private void SetupTopImage()
    {
        TopImage.gameObject.SetActive(true);
        PanelController.Instance.InfoIamge = TopImage;
    }

    private Quest GetRandomQuest()
    {
        TYPES rType = (TYPES)random.Next(0, 8);
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
            case TYPES.TYPE7:
                return new QType7(Type);
            case TYPES.TYPE8:
                return new QType8(Type);
            default:
                return new QType1(Type);
        }
    }

    public void StartHelp()
    {
        if (helpLocked)
            return;
        FractionGroup.OffInteractiveAll();
        Deselect();
        SetupTopImage();
        PanelController.Instance.SetChooseMode();

        GameController.Game.UserMadeTurn = true;
        GameController.Game.WhoWasAsked = Type;

        FractionHelp help = FractionGroup.Group[Type].GetHelp();

        Fractions lowRateFraction = FractionGroup.GetLowestRateFractionExceptOne(help._whichHelp.Type).Type;
        ResTypes lowValueResource = ResourceGroup.GetLowestValueResourceExceptOne(help._whichHelp.TypeRes).Type;
        help.InsertInTextFractionName(lowRateFraction);
        help.InsertInTexResourceName(lowValueResource);

        PanelController.SetUpPanel(help);

        StartCoroutine(Animation());
    }

    

    protected virtual FractionHelp GetHelp()
    {
        return null;
    }

    public void OnInteractive()
    {
        _imageButton.enabled = true;
    }
    public void OffInteractive()
    {
        _imageButton.enabled = false;
    }
    private void SetGreenFlag()
    {
        greenFlag.gameObject.SetActive(true);
    }

    private void SetRedFlag()
    {
        redFlag.gameObject.SetActive(true);
    }

    private void ResetFlags()
    {
        greenFlag.gameObject.SetActive(false);
        redFlag.gameObject.SetActive(false); ;
    }

    private void LockHelp()
    {
        HelpButton help = (HelpButton)_help;
        help.Transparent = 0.25f;
        helpLocked = true;
    }

    private void UnlockHelp()
    {
        HelpButton help = (HelpButton)_help;
        help.Transparent = 0.75f;
        helpLocked = false;
    }

    public void SetMark()
    {
        exclamationMark = true;
        Mark.gameObject.SetActive(true);
    }

    public void ResetMark()
    {
        exclamationMark = false;
        Mark.gameObject.SetActive(false);
    }

    public virtual void InitQuests()
    {
        
    }

    public virtual void InitHelpInfo()
    {
        
    }
}
