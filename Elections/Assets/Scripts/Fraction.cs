using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public enum Fractions
{
    OLIGARCH, PEOPLE, MAFIA, WARRIOR
}

public class Fraction : MonoBehaviour
{
    public GameButton _quest;
    public GameButton _help;
    public SelectableIcon _background;
    public SelectableIcon _image;

    protected int _rate;

    public int Rate
    {
        get { return _rate; }
        set
        {
            int buffer = _rate;
            _rate = value;
            if (_rate > 100)
                _rate = 100;
            if (_rate < 0)
                _rate = 0;
            int diff = value - buffer;
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
}
