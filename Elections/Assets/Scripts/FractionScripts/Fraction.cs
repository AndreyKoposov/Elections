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
    public Image TopImage;
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

    public virtual Fractions Type
    {
        get;
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

        PanelController.Instance.MoveToCenter();

        yield return new WaitForSeconds(0.5f);

        DarkController.Instance.ResetDark();
        MoveTopImageToPanel();
    }

    public void StartQuest()
    {
        Deselect();
        TopImage.gameObject.SetActive(true);

        StartCoroutine(Animation());

        //_userMadeTurn = true;

        Random random = new Random();
        TYPES rType = (TYPES)random.Next(0, 6);
        Quest quest = null;
        switch (rType)
        {
            case TYPES.TYPE1:
                quest = new QType1(Type);
                break;
            case TYPES.TYPE2:
                quest = new QType2(Type);
                break;
            case TYPES.TYPE3:
                quest = new QType3(Type);
                break;
            case TYPES.TYPE4:
                quest = new QType4(Type);
                break;
            case TYPES.TYPE5:
                quest = new QType5(Type);
                break;
            case TYPES.TYPE6:
                quest = new QType6(Type);
                break;
        }

        PanelController panel = PanelController.Instance;
        panel.SetText(quest._info._text);
        panel.SetLeftButtonText(quest._info._yesAnswer);
        panel.SetRightButtonText(quest._info._noAnswer);
        panel.Left = quest._taskAcception;
        panel.Right = quest._taskDeviation;
    }
}
