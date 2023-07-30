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
    private static Dictionary<Fractions, string> gameOverTexts;
    private static string PATH = Application.dataPath + "/Resources/Data/";
    private const string SYSTEMS_FILE_NAME = "systems.txt";
    private const string PLANETS_FILE_NAME = "planets.txt";
    private const string NAMES_FILE_NAME = "names.txt";
    private const string IMPERIES_FILE_NAME = "Imperies.txt";
    private const string COLONIES_FILE_NAME = "colonies.txt";
    private const string START_TEXT_FILE_NAME = "start_text.txt";
    private const string GAME_OVER_TEXT_FILE_NAME = "game_over.txt";
    private const string LEARN_TEXT_FILE_NAME = "learnText.txt";

    public static void InitAllData()
    {
        systems = GetListFromFile(SYSTEMS_FILE_NAME);
        planets = GetListFromFile(PLANETS_FILE_NAME);
        names = GetListFromFile(NAMES_FILE_NAME);
        imperies = GetListFromFile(IMPERIES_FILE_NAME);
        colonies = GetListFromFile(COLONIES_FILE_NAME);
        startText = GetTextFromFile(START_TEXT_FILE_NAME);
        learnText = GetTextFromFile(LEARN_TEXT_FILE_NAME);
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

    public static string RandomSystem
    {
        get
        {
            Random random = new Random();
            int randIndex = random.Next(0, systems.Count);
            return systems[randIndex];
        }
    }
    public static string RandomPlanet
    {
        get
        {
            Random random = new Random();
            int randIndex = random.Next(0, planets.Count);
            return planets[randIndex];
        }
    }
    public static string RandomColonie
    {
        get
        {
            Random random = new Random();
            int randIndex = random.Next(0, colonies.Count);
            return colonies[randIndex];
        }
    }
    public static string RandomName
    {
        get
        {
            Random random = new Random();
            int randIndex = random.Next(0, names.Count);
            return names[randIndex];
        }
    }
    public static string RandomImperia
    {
        get
        {
            Random random = new Random();
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

    public static Dictionary<Fractions, string> GameOverTexts
    {
        get { return gameOverTexts; }
    }
}
