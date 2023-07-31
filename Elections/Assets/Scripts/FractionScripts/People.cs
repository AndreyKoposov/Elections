using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class People : Fraction
{
    private const Fractions TYPE = Fractions.PEOPLE;
    private const ResTypes _typeRes = ResTypes.FOOD;
    private const string PATH = "Quests/people.txt";
    private const string PATH_TO_HELP_FILE = "Quests/people_help.txt";
    public static List<QuestINFO> Quests = new List<QuestINFO>();
    public static FractionHelpINFO _info;


    public override Fractions Type
    {
        get { return TYPE; }
    }
    public override ResTypes TypeRes
    {
        get { return _typeRes; }
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
    protected override FractionHelp GetHelp()
    {
        FractionHelp help = new FractionHelp(this, _info);
        return help;
    }
}
