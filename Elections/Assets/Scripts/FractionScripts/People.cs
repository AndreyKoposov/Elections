using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class People : Fraction
{
    private const Fractions TYPE = Fractions.PEOPLE;
    private const string PATH = "Quests/people.txt";
    private const string PATH_TO_HELP_FILE = "Quests/people_help.txt";


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
