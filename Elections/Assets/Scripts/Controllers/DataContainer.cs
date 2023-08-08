using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = System.Random;

public class DataContainer
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
    private static string PATH = Application.dataPath + "/Resources/Data/";
    private static Random random = new Random();
    private const string SYSTEMS_FILE_NAME = "systems.txt";
    private const string PLANETS_FILE_NAME = "planets.txt";
    private const string NAMES_FILE_NAME = "names.txt";
    private const string IMPERIES_FILE_NAME = "Imperies.txt";
    private const string COLONIES_FILE_NAME = "colonies.txt";
    private const string START_TEXT_FILE_NAME = "start_text.txt";
    private const string GAME_OVER_TEXT_FILE_NAME = "game_over.txt";
    private const string LEARN_TEXT_FILE_NAME = "learnText.txt";
    private const string LEARN_MARK_TEXT_FILE_NAME = "learnMarkText.txt";

    public static void InitAllData()
    {
        systems = GetListFromFile(SYSTEMS_FILE_NAME);
        planets = GetListFromFile(PLANETS_FILE_NAME);
        names = GetListFromFile(NAMES_FILE_NAME);
        imperies = GetListFromFile(IMPERIES_FILE_NAME);
        colonies = GetListFromFile(COLONIES_FILE_NAME);
        startText = GetTextFromFile(START_TEXT_FILE_NAME);
        learnText = GetTextFromFile(LEARN_TEXT_FILE_NAME);
        learnMarkText = GetTextFromFile(LEARN_MARK_TEXT_FILE_NAME);
        gameOverTexts = GetDictFromFile(GAME_OVER_TEXT_FILE_NAME);
    }

    private static List<string> GetListFromFile(string fileName)
    {
        List<string> list = new List<string>();
        try
        {
            StreamReader reader = new StreamReader(PATH + fileName);
            string line = reader.ReadLine();
            while (line != null)
            {
                list.Add(line);
                line = reader.ReadLine();
            }
            reader.Close();
        }
        catch
        {
            return list;
        }
        return list;
    }

    private static string GetTextFromFile(string fileName)
    {
        string text = "";
        try
        {
            StreamReader reader = new StreamReader(PATH + fileName);
            text = reader.ReadLine();
            reader.Close();
        }
        catch
        {
            return text;
        }
        return text;
    }

    private static Dictionary<Fractions, string> GetDictFromFile(string fileName)
    {
        Dictionary<Fractions, string> dict = new Dictionary<Fractions, string>();
        try
        {
            StreamReader reader = new StreamReader(PATH + fileName);
            int counter = 0;
            string line = reader.ReadLine();
            while (line != null)
            {
                dict.Add((Fractions)counter, line);
                line = reader.ReadLine();
                counter++;
            }
            reader.Close();
        }
        catch
        {
            return dict;
        }
        return dict;
    }

    public static FractionHelpINFO ParseFileToInfoObj(string path)
    {
        List<string> linesForConstructor = new List<string>();
        FractionHelpINFO info = new FractionHelpINFO("", "", "");
        try
        {
            StreamReader reader = new StreamReader(PATH + path);
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

    public static void ReadQuestsFileToList(string path, List<QuestINFO> quests)
    {
        List<string> linesForConstructor = new List<string>();
        try
        {
            StreamReader reader = new StreamReader(PATH + path);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Equals("END"))
                {
                    QuestINFO info = CreateQuestINFO(linesForConstructor);
                    quests.Add(info);
                    linesForConstructor.Clear();
                }
                else
                {
                    linesForConstructor.Add(line);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("Ошибка считывания файла: " + e.Message);
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

    public static string RandomSystem
    {
        get
        {
            int randIndex = random.Next(0, systems.Count);
            return systems[randIndex];
        }
    }
    public static string RandomPlanet
    {
        get
        {
            int randIndex = random.Next(0, planets.Count);
            return planets[randIndex];
        }
    }
    public static string RandomColonie
    {
        get
        {
            int randIndex = random.Next(0, colonies.Count);
            return colonies[randIndex];
        }
    }
    public static string RandomName
    {
        get
        {
            int randIndex = random.Next(0, names.Count);
            return names[randIndex];
        }
    }
    public static string RandomImperia
    {
        get
        {
            int randIndex = random.Next(0, imperies.Count);
            return imperies[randIndex];
        }
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
