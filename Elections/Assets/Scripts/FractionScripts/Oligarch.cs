using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Oligarch : Fraction
{
    private const Fractions TYPE = Fractions.OLIGARCH;
    private const string PATH = "Quests/oligarch.txt";
    private const string PATH_TO_HELP_FILE = "Quests/oligarch_help.txt";


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
