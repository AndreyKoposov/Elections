using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Fraction
{
    private const Fractions TYPE = Fractions.WARRIOR;
    private const string PATH = "Quests/warrior.txt";
    private const string PATH_TO_HELP_FILE = "Quests/warrior_help.txt";
    public static List<QuestINFO> Quests = new List<QuestINFO>();
    public static FractionHelpINFO _info;



    public override Fractions Type
    {
        get { return TYPE; }
    }

    public static void InitQuests()
    {
        Quests.Clear();
        DataContainer.ReadQuestsFileToList(PATH, Quests);
    }

    public static void InitHelpInfo()
    {
        _info = DataContainer.ParseFileToInfoObj(PATH_TO_HELP_FILE);
    }
}
