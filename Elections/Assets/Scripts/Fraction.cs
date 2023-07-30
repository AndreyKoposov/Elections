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
        }
    }

    public virtual Fractions Type
    {
        get;
    }

    private void Start()
    {
        _rate = 50;
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

    protected static FractionHelpINFO ParseFileToInfoObj(string PATH)
    {
        List<string> linesForConstructor = new List<string>();
        FractionHelpINFO info = new FractionHelpINFO("", "", "");
        try
        {
            StreamReader reader = new StreamReader(PATH);
            string line = reader.ReadLine();
            while (line != null)
            {
                linesForConstructor.Add(line);
                line = reader.ReadLine();
            }
        }
        catch (Exception e)
        {
            throw new Exception("Ошибка считывания файла: " + e.Message);
        }

        info = CreateFractionHelpINFO(linesForConstructor);
        return info;
    }

    private static FractionHelpINFO CreateFractionHelpINFO(List<string> lines)
    {
        string text = lines[0];
        string yes = lines[1];
        string no = lines[2];

        FractionHelpINFO info = new FractionHelpINFO(text, yes, no);
        return info;
    }
    protected static QuestINFO CreateQuestINFO(List<string> lines)
    {
        string text = lines[0];
        string yes = lines[1];
        string no = lines[2];
        List<Fractions> fractions = new List<Fractions>();
        List<ResTypes> resources = new List<ResTypes>();

        if (!isNoneLine(lines[3]))
        {
            ParseFractionsLineToList(lines[3], fractions);
        }

        if (!isNoneLine(lines[4]))
        {
            ParseResourcesLineToList(lines[4], resources);
        }

        TYPES type = (TYPES)Int32.Parse(lines[5]);

        QuestINFO info = new QuestINFO(text, yes, no, type, fractions, resources);
        return info;
    }

    private static bool isNoneLine(string line)
    {
        return line.Equals("NONE");
    }

    private static void ParseFractionsLineToList(string line, List<Fractions> list)
    {
        string[] fractionsWords = line.Split(' ');
        for (int i = 0; i < fractionsWords.Length; i++)
        {
            Fractions fraction = ParseFractions(fractionsWords[i]);
            list.Add(fraction);
        }
    }

    private static void ParseResourcesLineToList(string line, List<ResTypes> list)
    {
        string[] resourcesWords = line.Split(' ');
        for (int i = 0; i < resourcesWords.Length; i++)
        {
            ResTypes res = ParseResources(resourcesWords[i]);
            list.Add(res);
        }
    }

    public static Fractions ParseFractions(string text)
    {
        Fractions fraction = (Fractions)Int32.Parse(text);
        return fraction;
    }

    public static ResTypes ParseResources(string text)
    {
        ResTypes res = (ResTypes)Int32.Parse(text);
        return res;
    }
    public static int CompareFraction(Fraction x, Fraction y)
    {
        return x.Rate.CompareTo(y.Rate);
    }

    public virtual void MoveTopImageToCenter()
    {
        TopImage.gameObject.SetActive(true);
        LeanTween.moveLocal(TopImage.gameObject, new Vector3(0, -30, 0), 0.4f);
        LeanTween.scale(TopImage.gameObject, new Vector3(1.6f, 1.6f, 1.6f), 0.4f);
    }

    public void StartQuest()
    {
        _image.Deselect();
        MoveTopImageToCenter();
        DarkController.Instance.MakeDark();

        //_userMadeTurn = true;
        return;
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
    }
}
