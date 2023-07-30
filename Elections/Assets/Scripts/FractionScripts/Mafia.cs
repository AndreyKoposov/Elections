using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia : Fraction
{
    private const Fractions TYPE = Fractions.MAFIA;
    private const string PATH = "Quests/mafia.txt";
    private const string PATH_TO_HELP_FILE = "Quests/mafia_help.txt";

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
