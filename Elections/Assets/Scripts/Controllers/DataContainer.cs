using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class DataContainer : MonoBehaviour
{

    private static List<string> systems;
    private static List<string> planets;
    private static List<string> names;
    private static List<string> imperies;
    private static List<string> colonies;
    private static string startText;
    private static string learnText;
    private static string learnMarkText;
    private static Dictionary<Fractions, string> gameOverTexts;
    private static Random random = new Random();

    [SerializeField] private TextAsset SYSTEMS_FILE;
    [SerializeField] private TextAsset PLANETS_FILE;
    [SerializeField] private TextAsset NAMES_FILE;
    [SerializeField] private TextAsset IMPERIES_FILE;
    [SerializeField] private TextAsset COLONIES_FILE;
    [SerializeField] private TextAsset START_TEXT_FILE;
    [SerializeField] private TextAsset GAME_OVER_TEXT_FILE;
    [SerializeField] private TextAsset LEARN_TEXT_FILE;
    [SerializeField] private TextAsset LEARN_MARK_TEXT_FILE;
    private static DataContainer instance;

    private void Awake()
    {
        instance = this;
    }

    public static DataContainer Instance
    {
        get { return instance; }
    }

    public void InitAllData()
    {
        systems = GetListFromFile(SYSTEMS_FILE);
        planets = GetListFromFile(PLANETS_FILE);
        names = GetListFromFile(NAMES_FILE);
        imperies = GetListFromFile(IMPERIES_FILE);
        colonies = GetListFromFile(COLONIES_FILE);
        startText = GetTextFromFile(START_TEXT_FILE);
        learnText = GetTextFromFile(LEARN_TEXT_FILE);
        learnMarkText = GetTextFromFile(LEARN_MARK_TEXT_FILE);
        gameOverTexts = GetDictFromFile(GAME_OVER_TEXT_FILE);
    }

    private static List<string> GetListFromFile(TextAsset asset)
    {
        List<string> list = new List<string>(asset.text.Split('\n'));
        
        return list;
    }

    private static string GetTextFromFile(TextAsset asset)
    {
        string text = asset.text;
     
        return text;
    }

    private static Dictionary<Fractions, string> GetDictFromFile(TextAsset asset)
    {
        Dictionary<Fractions, string> dict = new Dictionary<Fractions, string>();
        string[] lines = asset.text.Split('\n');
        for(int i = 0; i < lines.Length; i++)
        {
            dict.Add((Fractions)i, lines[i]);
        }
       
        return dict;
    }

    public static FractionHelpINFO ParseFileToInfoObj(TextAsset asset)
    {
        List<string> linesForConstructor = new List<string>(asset.text.Split('\n'));
        FractionHelpINFO info = new FractionHelpINFO("", "", "");

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

    private static QuestINFO CreateQuestINFO(List<string> lines)
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

    public static void ReadQuestsFileToList(TextAsset asset, List<QuestINFO> quests)
    {
        List<string> linesForConstructor = new List<string>();
        string[] lines = asset.text.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("END"))
            {
                QuestINFO info = CreateQuestINFO(linesForConstructor);
                quests.Add(info);
                linesForConstructor.Clear();
            }
            else
            {
                linesForConstructor.Add(lines[i]);
            }
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

    private static bool isNoneLine(string line)
    {
        return line.Contains("NONE");
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

    public static string RandomSystem
    {
        get
        {
            int randIndex = random.Next(0, systems.Count);
            return RemoveCRLF(systems[randIndex]);
        }
    }
    public static string RandomPlanet
    {
        get
        {
            int randIndex = random.Next(0, planets.Count);
            return RemoveCRLF(planets[randIndex]);
        }
    }
    public static string RandomColonie
    {
        get
        {
            int randIndex = random.Next(0, colonies.Count);
            return RemoveCRLF(colonies[randIndex]);
        }
    }
    public static string RandomName
    {
        get
        {
            int randIndex = random.Next(0, names.Count);
            return RemoveCRLF(names[randIndex]);
        }
    }
    public static string RandomImperia
    {
        get
        {
            int randIndex = random.Next(0, imperies.Count);
            return RemoveCRLF(imperies[randIndex]);
        }
    }

    private static string RemoveCRLF(string text)
    {
        return text.Replace("\r", "").Replace("\n", "");
    }

    public static string StartText
    {
        get
        {
            return startText;
        }
    }

    public static string LearnText
    {
        get
        {
            return learnText;
        }
    }

    public static string LearnMarkText
    {
        get
        {
            return learnMarkText;
        }
    }

    public static Dictionary<Fractions, string> GameOverTexts
    {
        get { return gameOverTexts; }
    }
}
