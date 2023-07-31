using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Fraction
{
    private const Fractions TYPE = Fractions.WARRIOR;
    private const ResTypes _typeRes = ResTypes.POWER;
    private const string PATH = "Quests/warrior.txt";
    private const string PATH_TO_HELP_FILE = "Quests/warrior_help.txt";
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
